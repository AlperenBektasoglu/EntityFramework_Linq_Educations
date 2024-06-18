# CodeFirst - Migrations

## Code First Yaklaşımı

Veritabanı ile Programlama dili arasında bağ kuran bir tekniktir. Projenizde veritabanı işlemlerinizi mümkün mertebe Visual Studio tarafında kod yazarak gerçekleştirmenizi sağlayan bir yaklaşımdır. Bu yaklaşım sayesinde veritabanı arayüzü ile yazılımcı arasında ilişki minimize edilmektedir.

Code First yapısında programlama dilindeki “class” yapıları veritabanındaki “tablo” yapılarına, “property” yapıları ise veritabanındaki “kolon” yapılarına denk gelmektedir.

Ayrıca Attribute’lar sayesinde veritabanı yapılarına Validationlar uygulanabilmekte ve kolonlara belirli şartlar veyahut kısıtlamalar koyulabilmektedir.

Bu arada Mapping işlemi kısaca tablolarımızdaki kısıtlarımızı belirlediğimiz olaydır. Attribute’ların yanında farklı yöntemlerlede bu işlemleri gerçekleştirebilmekteyiz. Örnek vermek gerekirse Fluent Api veya Fluent Validation gibi araçlar Mapping işlemleri için popüler olarak kullanılmaktadır.

**Not:** Tablodaki kolonlara kısıt eklerken attributeler(Data Anotations) yerine Fluent Api kullanımı tavsiye edilir.

## Migrations

Öncelikle projeye EntityFramework kütüphanesini Nuget Package Manager'dan indir. Ardından yapıları(Entities, Context, ConnectionString) oluştur. Devamında migration'ı aktif edebilmek için aşağıdaki kodu consola yaz.

```
enable-migrations
```

Oluşan configuration dosyasında AutomaticMigrationsEnabled değerini true yapılırsa, yönetim EntityFramework'e devredilmiş olur ve oluşan migration içeriğini göremezsiniz. Ve değişiklikleri kaydedebilmek ve veritabanına yansımasını sağlamak için aşağıdaki kodu yazmanız yeterlidir.

```
update-database
```

**Not:** Oluşan configuration dosyasında Seed metodu içerisine yazılan kodlar, "update-database" komutundan sonra her defasında çalıştırılır. Burada tabloya veri eklemek için kod yazabilirsin.

Lakin AutomaticMigrationsEnabled özelliğinin false olması önerilir. Çünkü oluşan migrationları görüp inceleyebilir, hatalı bir migration oluşmuş ise veritabanına yansıtmadan önce güncelleyebiliriz. Örnek olarak bir tablodaki kolon ismini güncellediğinizde o kolondaki veriler kaybolur. Oluşan migrationda yada veritabanında bunun için önlem alabilirsiniz. Değişiklikleri kaydedebilmek ve veritabanına yansımasını sağlamak için aşağıdaki kodu yazmanız yeterlidir.

```
add-migration [MigrationAdı]
update-database
```

**Not:** update-database komutu son oluşan migration'ı veritabanına uygular. Migration'a isim verirken anlamlı isimler vermeye dikkat edilmelidir.

**Not:** Oluşan migration'da Up() ve Down() metodları vardır.

- Up Metodu: Yapılan değişiklikleri veritabanına nasıl yapılacağını gösterir.
- Down Metodu: Migration geri alındığında ise çalışacak kodlar burada gösterilir.

AutomaticMigrationsEnabled true iken code first anlatımı:
<a href="https://www.youtube.com/watch?v=-oMRS2ps39s&list=PL3fase39I1X0nYYu3VQwCo4YTQ8ck3D6N&index=10"> Entity Framework Code First ile Database oluşturma </a>
AutomaticMigrationsEnabled false iken code first anlatımı:
<a href="https://www.youtube.com/watch?v=0DJfBxD_rgE&list=PL3fase39I1X0nYYu3VQwCo4YTQ8ck3D6N&index=11">Entity Framework Code First Migration Kullanarak Database Oluşturma</a>
Migrationlar üzerinde ileri geri gitme anlatımı:
<a href="https://www.youtube.com/watch?v=VRf9aGdYgAw&list=PL3fase39I1X0nYYu3VQwCo4YTQ8ck3D6N&index=12">Entity Framework MigrationHistory Tablosu ve Up() ,Down() metotları</a>

Tablodaki kolonlara özellik eklerken(maxlength, primarykey, unique vs.) Data Anotations'lar yada Fluent Api kullanılabilir. Fluent Api kullanımı tavsiye edilir.
<a href="https://www.youtube.com/watch?v=zZAl5kqUVBg&list=PLqG356ExoxZUXrL_AGvFug_XnxdxvF935&index=10">Entity Framework - Data Annotations</a>
<a href="https://www.youtube.com/watch?v=JZqzauuFmTI">Entity Framework Fluent API</a>
