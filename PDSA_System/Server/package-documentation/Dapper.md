# Dapper - Objekt Mapper i .NET

## Funksjoner
Dapper er en NuGet bibliotek som tilbyr ytterligere utvidelse av ***IDbConnection*** sitt grensesnitt.

Det tilbyr tre forskjellige hjelpere.

### Foreta forspørsler (querys) og mappe ut resultatet til en lsite  

```cs
public class Dog
{
    public int? Age { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float? Weight { get; set; }

    public int IgnoredProperty { get { return 1; } }
}

var guid = Guid.NewGuid();
var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });

Assert.Equal(1,dog.Count());
Assert.Null(dog.First().Age);
Assert.Equal(guid, dog.First().Id);
{
```

### Foreta forespørsler og map det til lister av dynamiske objekter   
```cs
public static IEnumerable<dynamic> Query (this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
```  

***Eksempel***   
```cs
var rows = connection.Query("select 1 A, 2 B union all select 3, 4").AsList();

Assert.Equal(1, (int)rows[0].A);
Assert.Equal(2, (int)rows[0].B);
Assert.Equal(3, (int)rows[1].A);
Assert.Equal(4, (int)rows[1].B);
```

### Foreta Kommandoer som returnerer ikke noe resultat.  

``` cs
public static int Execute(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
```

***Eksemepel***   
```cs
var count = connection.Execute(@"
  set nocount on
  create table #t(i int)
  set nocount off
  insert #t
  select @a a union all select @b
  set nocount on
  drop table #t", new {a=1, b=2 });
Assert.Equal(2, count);
```


## Begrunnelse   
***Hentet fra:***   https://github.com/DapperLib/Dapper#readme 

Dapper cacher informasjon om hvert søk den kjører, dette lar den materialisere objekter raskt og behandle parametere raskt. Den gjeldende implementeringen cacher denne informasjonen i et ConcurrentDictionary-objekt. Utsagn som bare brukes én gang, blir rutinemessig tømt fra denne hurtigbufferen. Likevel, hvis du genererer SQL-strenger i farten uten å bruke parametere, er det mulig du kan få minneproblemer.

Dappers enkelhet betyr at mange funksjoner som ORM-er leveres med, fjernes. Den bekymrer seg for 95 %-scenariet, og gir deg verktøyene du trenger mesteparten av tiden. Den prøver ikke å løse alle problemer.   


