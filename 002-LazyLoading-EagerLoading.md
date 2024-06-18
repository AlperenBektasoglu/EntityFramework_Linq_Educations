# Lazy Loading - Eager Loading

**Navigation Property:** Navigasyon özelliği, bir ilişkilendirmenin bir ucundan diğer ucuna gezinmeye izin veren bir Entity türü üzerindeki isteğe bağlı bir özelliktir. Başka bir ifade ile veritabanında bir foreign key ilişkisini temsil etmenin veya iki entity arasındaki ilişkiyi tanımlamanın bir yoludur.

## Lazy Loading

Bu yaklaşım verilere “ihtiyaç duyulduğunda” ulaşmak için oluşturulmuş bir stratejidir.

Üst nesnenin ilişkili olduğu alt nesneler eğer talep edilirlerse, ayrı sorgularla veritabanından alınarak ilgili nesneye eklenirler.

Burada iç içe ilişkili çok sayıda veri olması bir nesnenin elde edilmesi için çok fazla sorgu atılması anlamına gelebilir. Performans anlamında buna dikkat edilmelidir.

**Not:** Lazy Loading: Lazy loading varsayılan olarak etkinse, ilişkili nesneler ilk erişimde yüklenir. Lazy loading'i etkinleştirmek için virtual anahtar kelimesi kullanılır.

```cs
public class Order
{
    public int OrderId { get; set; }
    public virtual Customer Customer { get; set; } // Lazy loading
}
```

## Eager Loading

Eager loading Linq sorgusu çalıştırıldığında verilerin tamamını yükler ve hafızaya alır.

Aşağıdaki örnekte ilk olarak lazyloading özelliği disable edildi. Bu sayede default olarak tanımlanan lazy loading özelliği pasif hale geliyor. Include metodu ile artık “Person” entitylerini sorgularken buna “Personphone” entitylerini de dahil ediyoruz. Yani entityleri daha sorgu sırasında birbirine bağlayıp tek seferde çekiyoruz.

```cs
using (AdventureWorks2012Entities context = new AdventureWorks2012Entities())
   {
      context.Configuration.LazyLoadingEnabled = false;

       var Kisiler = from tel in context.Person.Include("PersonPhone").Take(10) select tel;
       // var Kisiler = context.Person.Include("PersonPhone").Take((10)).ToList(); sorgusu da aynı işi görecektir.

       foreach (var kisi in Kisiler)
       {
         Console.WriteLine(kisi.FirstName+" "+ kisi.LastName);

         foreach (var telefon in kisi.PersonPhone)
         {
            Console.WriteLine("Tel : " + telefon.PhoneNumber);
         }

      }
  }
```

**Not:** Eager Loading: Include veya ThenInclude metotları kullanılır.

```cs
var orders = context.Orders.Include(o => o.Customer).ToList();
```

**Not:** Bir sorgu çalıştırmadan önce kodu gözden geçirin. Include kullanımı eager loading, virtual kullanımı lazy loading göstergesidir.
Entity Framework'te duruma göre lazy veya eager loading yapabilirsiniz. Bunu başarmak için ilişkili özelliklerinizi virtual anahtar kelimesi ile tanımlayabilir ve sorgularınızda Include yöntemini kullanabilirsiniz.

## Lazy Loading ve Eager Loading’in Avantaj/Dezavantajları

Uygulamanın ihtiyaçlarını tam olarak bilmeden hangi loading türünün daha avantajlı olduğunu söyleyemeyiz. İki türün de kendine göre avantajları ve dezavantajları mevcut.

- Yukarıda detaylıca anlatıldığı üzere , lazy loading ile birbiriyle ilişkili olan entityler ihtiyaç oldukça çekilir. Bu da bize içinde bulunduğumuz case’e göre performans açısından yarar sağlayabilir.
- Lazy loading ilişkili entityleri ihtiyaç oldukça çektiğinden yukarıdaki örneklerde de görüldüğü gibi eager loading’e göre veritabanına çok daha fazla kez bağlanır ve sorgu atar bunun da program için bir maliyeti vardır. Eager loading ise tek sorguda gerekli bilgileri elde eder.Örnek üzerinden gitmek gerekirse ;

Bir sayfada verileri listeleyeceğimizi düşünelim ve listeleyeceğimiz sayfada birbiriyle ilişkili entitylerin bilgileri bir arada sunulacak olsun, yani yukarıdaki örneği baz alırsak kişiler (person) listelenirken listede kişilerin telefonu da(personPhone) aynı satırda gözükecek olsun. Bu durumda lazy loading kullanırsak binlerce kayıt için tek tek veritabanına gidip binlerce sorgu atacaktır. Halbuki bu telefon kayıtlarına daha kişi yani person kayıtlarına ihtiyaç duyduğumuz anda ihtiyaç duyuyoruz yani bu durumda ilişkili kayıtları tek seferde çekmek yani eager loading kullanmak daha avantajlı olacaktır. Ancak eğer birbiriyle ilişkili bilgiler bir arada görünmeyecek kısımlardaysa ve başka sayfadalarsa ilgili noktaya gittiğimizde açılacaklarsa bu durumda bu verileri o an ihtiyacımız olduğunda çekmek daha mantıklıdır.

Kaynak: <a href="https://www.youtube.com/watch?v=OrKFd13wnIc&list=PL3fase39I1X0nYYu3VQwCo4YTQ8ck3D6N&index=9">Entity Framework LazyLoading, EagerLoading, Navigation Property Kavramları</a>
