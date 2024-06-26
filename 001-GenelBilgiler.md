# Entity Framework Nedir?

Entity Framework ORM(Object Relational Mapping) araçlarından biridir. ORM nedir dersek: İlişkisel veritabanı ile nesneye yönelik programlama(OOP) arasında bir köprü görevi gören araçtır. Bu köprü, ilişkisel veritabanındaki bilgilerimizi yönetmek için nesne modellerimizi kullandığımız bir yapıdır. Kısaca veritabanına bizim nesnelerimizi bağlayan ve bizim için veri alışverişini yapan Microsoft tarafından geliştirilmiş bir framework’tür.

Entity Framework(EF) Ado.Net altyapısını kullanmaktadır. İçerisinde UnitOfWork design pattern’nini barındırmaktadır. Nedir bu Ado.Net nedir Bu UnitOfWork dersek Ado.Net kısaca Microsoft tarafından yazılmış veri erişim teknolojisidir. Günümüzde hala kullanılmaktadır ancak yavaş yavaş yerini ORM teknolojilerine bırakmaktadır çünkü veritabanı işlemleri için Ado.Net kullanırsanız birçok işi kendiniz yapmanız gerekmektedir. Örnek vermek gerekirse Ekleme,Silme,Güncelleme ve diğer sorgular için String formatında sorgu cümleciklerini oluşturmanız gerekecektir buda büyük bir projede ayrı bir yük getirmektedir. UnitOfWork ise yapılan her değişkliğin anlık olarak veritabanına yansıması yerine, bu işlemlerin toplu halde tek bir kanal üzerinden gerçekleşmesini sağlar.

Entity Framework ile 4 farklı yöntem kullanarak proje geliştirebilirsiniz. Bu yöntemler;

- Model First (Yeni Veritabanı Oluşturma Visual Studio İle)
- Database First (Var Olan Veritabanını Kullanma)
- Code First (Yeni Veritabanı Kod Yazarak)
- Code First(Var Olan Veritabanını Kullanma)

**Model First:** Bu yöntem Visual Studio üzerinde boş bir model dosyası (.edmx) eklenerek veritabanını bu model üzerinde tasarlanabilmesine olanak sağlıyor. Derleme adımında verilen script dosyası veritabanını oluşturur.

**Database First:** Bu yöndem önceden oluşturulmuş olan veritabanını projeye model olarak bağlayarak gerekli classlarımız Entity Framework tarafından oluşturulmaktadır.

**Code First (Kod Yazarak):** Bu yöntem (Ki benim en sevdiğim) classlarımızı visual studio ortamında oluşturmaya başlayarak gerçekleştirdiğimiz bir yöntemdir. Veritabanımız bu classlardan türetilmektedir. Burada Mapping işlemleri yazılımcı tarafından classlar oluşturulurken Attribute’lar sayesinde yapılabilmektedir. Bu arada Mapping işlemi kısaca tablolarımızdaki kısıtlarımızı belirlediğimiz olaydır. Attribute’ların yanında farklı yöntemlerlede bu işlemleri gerçekleştirebilmekteyiz. Örnek vermek gerekirse Fluent Api veya Fluent Validation gibi araçlar Mapping işlemleri için popüler olarak kullanılmaktadır.

**Code First (Var Olan Veritabanını Kullanma):** Bu yöntemde de classlar ve mapping kodları yazılımcı tarafından oluşturulmaktadır. Veritabanımız classlarımızın ve modellemenin durumuna göre güncellenmektedir.

## Avantajları

- OOP olarak kod geliştirmemize olanak tanır.
- Hiçbir SQL bilgisi olmayan bir kimse veritabanı işlemlerini EF ile gerçekleştirebilir.
- Herhangi bir veritabanına bağımlılık yoktur. Oracle, MS SQL ile kullanılabilir.
- Code First sayesinde projenizi veritabanınızı taşıma gereği duymadan istediğiniz yerde oluşturabilirsiniz. Buda projelerinize büyük bir esneklik sağlamaktadir.
- Yazılım geliştirme zamanını azaltır.
- Yazılım geliştirme maaliyetini azaltır.

## Dezavantajları

- En büyük sorunumuz performans. Ado.Net gibi hızlı bir performansı yoktur. Tabi bu yavaş olduğu anlamına gelmez.
- Veritabanından veri alış-verişi yapılacağı zaman kontrol bizde değil Entity Frameworktedir. Yani arka planda veritabanı işlemleri için kendisi sorgular oluşturmaktadır. Basit bir veri işlemi için karmaşık bir sorgu gönderebilmektedir. Bu Sorguları SQL Server Profiler ile görüntüleyebilmektesiniz.
- Syntax’ı yeni kullanacak kişiler için karmaşık gelebilmektedir ancak zamanla alışacaksınız.
- Schema’da herhangi bir değişiklik yapıldığı zaman EF çalışmayacaktır. Sizin bu Schema’yı solution’da güncellemeniz gerekmektedir.
