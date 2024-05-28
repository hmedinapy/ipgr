---------------------------------------------------------------------------------------------------------
commands
---------------------------------------------------------------------------------------------------------
Scaffold-DbContext "Data Source=W4Q0SL33;Initial Catalog=dbTest5;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsCheck

Scaffold-DbContext "Name=DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsCheck
Scaffold-DbContext "name=DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsAAA -Project API.Data -Context DataBaseContext
	-Force


-- update model
dotnet ef migrations add AddAsp
add-migration
update-database
dotnet ef database update --project API-1.Data



-- update from
	DB -> code : 
		dotnet ef migrations has-pending-model-changes --project API-1.Data
		-> Changes have been made to the model since the last migration. Add a new migration.
		dotnet ef migrations add 'new update401' --project API-1.Data

	code -> DB

---------------------------------------------------------------------------------------------------------
check
---------------------------------------------------------------------------------------------------------
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

---------------------------------------------------------------------------------------------------------
como opera
---------------------------------------------------------------------------------------------------------
1. analisis de riesgo
2. con 1	 => IPGR (se genera con 2)
3. con 1 y 2 => matriz IPGR (se genera con 2)
4. con 2 y 3 => matriz Plan de Trabajo
5. con 4 	 => cronograma  (se genera con 4)

---------------------------------------------------------------------------------------------------------
selects 
---------------------------------------------------------------------------------------------------------
select * from dbTest5.dbo.analisis_riesgo

-- hoja 2 - Analisis de riesgo "human"
select d.descripcion dpto, a.descripcion area, r.descripcion riesgo, ar.* from dbTest5.dbo.analisis_riesgo ar
left join area a on ar.id_area = a.id  left join riesgo r on ar.id_riesgo = r.id 
left join departamento d on a.id_departamento = d.id

-- hoja 3 - IPGR (todo: reemplazar valores 15 y 30 por parámetros dependiente de empresa/auditoria)
select ar.codigo, a.descripcion, D.descripcion, avg(ar.resultado) "Resultado Promedio", 
case 
 WHEN avg(ar.resultado) <= 15 then 'Bajo'
 WHEN avg(ar.resultado) <= 30 then 'Medio'
 else 'Alto' end as 'Nivel de Riesgo'
from dbTest5.dbo.analisis_riesgo ar
left join area a on ar.id_area = a.id  left join riesgo r on ar.id_riesgo = r.id 
left join departamento d on a.id_departamento = d.id
group by ar.codigo, a.descripcion, D.descripcion
order by avg(ar.resultado) desc 


-- hoja 4 - plan_trabajo
select * from dbTest5.dbo.plan_trabajo

-- hoja 4 - plan_trabajo - puntos (levantamiento - descargo)
select pt.codigo, tp.descripcion, case tp.tipo_punto when 'L' then 'Levantamiento' when 'D' then 'Descargo' end Tipo
from dbTest5.dbo.plan_trabajo_puntos tp
left join plan_trabajo pt on tp.id_plan_trabajo = pt.id


---------------------------------------------------------------------------------------------------------
identity
---------------------------------------------------------------------------------------------------------
https://learn.microsoft.com/es-es/training/modules/secure-aspnet-core-identity/