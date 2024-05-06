Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.4"
Microsoft.EntityFrameworkCore.Tools" Version="8.0.4"

Scaffold-DbContext "Data Source=W4Q0SL33;Initial Catalog=dbTest3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


Scaffold-DbContext "Data Source=W4Q0SL33;Initial Catalog=dbTest3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

-- update model
add-migration
update-database

-- FK notation
public class Hotel {
	public int Id
	public int Name
	public int Address
	
	//take care of notation
	[ForeignKey(nameof(Country)]
	public int CountryId
	public Country Country
}