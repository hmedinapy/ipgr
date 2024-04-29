using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class upatebasedatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ruc = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    telefono = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    codigo_empresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    usuario_creacion = table.Column<int>(type: "int", nullable: true),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuario_modificacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "riesgo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    user_creado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riesgo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_empresa = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    apellido = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    usuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    clave = table.Column<string>(type: "text", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    telefono = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    mail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    fecha_creada = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    id_empresa = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_departamento_empresa",
                        column: x => x.id_empresa,
                        principalTable: "empresa",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_rol", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_rol_rol",
                        column: x => x.id_rol,
                        principalTable: "rol",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_rol_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    id_departamento = table.Column<int>(type: "int", nullable: false),
                    id_empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.id);
                    table.ForeignKey(
                        name: "FK_area_departamento",
                        column: x => x.id_departamento,
                        principalTable: "departamento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_area_empresa",
                        column: x => x.id_empresa,
                        principalTable: "empresa",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "analisis_riesgo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_area = table.Column<int>(type: "int", nullable: true),
                    id_riesgo = table.Column<int>(type: "int", nullable: true),
                    significado = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    agente_generador = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    causa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    efecto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    probabilidad = table.Column<int>(type: "int", nullable: false),
                    impacto = table.Column<int>(type: "int", nullable: false),
                    resultado = table.Column<int>(type: "int", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    nivel_riesgo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analisis_riesgo", x => x.id);
                    table.ForeignKey(
                        name: "FK_analisis_riesgo_area",
                        column: x => x.id_area,
                        principalTable: "area",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_analisis_riesgo_riesgo",
                        column: x => x.id_riesgo,
                        principalTable: "riesgo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "plan_trabajo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: true),
                    codigo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_departamento = table.Column<int>(type: "int", nullable: true),
                    objetivos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    procedimientos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cantidad_personas = table.Column<int>(type: "int", nullable: true),
                    horas_netas = table.Column<int>(type: "int", nullable: true),
                    productos = table.Column<int>(type: "int", nullable: true),
                    fecha_incio_auditoria = table.Column<DateOnly>(type: "date", nullable: false),
                    fecha_fin_auditoria = table.Column<DateOnly>(type: "date", nullable: false),
                    id_auditor_asignado = table.Column<int>(type: "int", nullable: true),
                    id_responsable_area_auditada = table.Column<int>(type: "int", nullable: true),
                    id_area_auditada = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    envio_informe = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    fecha_creada = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    id_user_creada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan_trabajo", x => x.id);
                    table.ForeignKey(
                        name: "FK_plan_trabajo_area",
                        column: x => x.id_area_auditada,
                        principalTable: "area",
                        principalColumn: "id");
                    //table.ForeignKey(
                    //    name: "FK_plan_trabajo_departamento_IdDepartamentoNavigation",
                    //    column: x => x.IdDepartamentoNavigation,
                    //    principalTable: "departamento",
                    //    principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_plan_trabajo_usuario",
                        column: x => x.id_auditor_asignado,
                        principalTable: "usuario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_plan_trabajo_usuario1",
                        column: x => x.id_responsable_area_auditada,
                        principalTable: "usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "plan_trabajo_puntos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_plan_trabajo = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    tipo_punto = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValue: "L"),
                    activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan_trabajo_puntos", x => x.id);
                    table.ForeignKey(
                        name: "FK_plan_trabajo_puntos_plan_trabajo",
                        column: x => x.id_plan_trabajo,
                        principalTable: "plan_trabajo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_analisis_riesgo_id_area",
                table: "analisis_riesgo",
                column: "id_area");

            migrationBuilder.CreateIndex(
                name: "IX_analisis_riesgo_id_riesgo",
                table: "analisis_riesgo",
                column: "id_riesgo");

            migrationBuilder.CreateIndex(
                name: "IX_area_id_departamento",
                table: "area",
                column: "id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_area_id_empresa",
                table: "area",
                column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_id_empresa",
                table: "departamento",
                column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_plan_trabajo_id_area_auditada",
                table: "plan_trabajo",
                column: "id_area_auditada");

            migrationBuilder.CreateIndex(
                name: "IX_plan_trabajo_id_auditor_asignado",
                table: "plan_trabajo",
                column: "id_auditor_asignado");

            migrationBuilder.CreateIndex(
                name: "IX_plan_trabajo_id_responsable_area_auditada",
                table: "plan_trabajo",
                column: "id_responsable_area_auditada");

            //migrationBuilder.CreateIndex(
            //    name: "IX_plan_trabajo_IdDepartamentoNavigation",
            //    table: "plan_trabajo",
            //    column: "IdDepartamentoNavigation");

            migrationBuilder.CreateIndex(
                name: "IX_plan_trabajo_puntos_id_plan_trabajo",
                table: "plan_trabajo_puntos",
                column: "id_plan_trabajo");

            migrationBuilder.CreateIndex(
                name: "IX_user_rol_id_rol",
                table: "user_rol",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_user_rol_id_usuario",
                table: "user_rol",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analisis_riesgo");

            migrationBuilder.DropTable(
                name: "plan_trabajo_puntos");

            migrationBuilder.DropTable(
                name: "user_rol");

            migrationBuilder.DropTable(
                name: "riesgo");

            migrationBuilder.DropTable(
                name: "plan_trabajo");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "empresa");
        }
    }
}
