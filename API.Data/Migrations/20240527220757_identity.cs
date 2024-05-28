using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "empresa",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        ruc = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        telefono = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        codigo_empresa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        usuario_creacion = table.Column<int>(type: "int", nullable: true),
            //        fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true),
            //        usuario_modificacion = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_empresa", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "riesgo",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        user_creado = table.Column<int>(type: "int", nullable: true),
            //        activo = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_riesgo", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "departamento",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        id_empresa = table.Column<int>(type: "int", nullable: false),
            //        activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_departamento", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_departamento_empresa",
            //            column: x => x.id_empresa,
            //            principalTable: "empresa",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "area",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        id_departamento = table.Column<int>(type: "int", nullable: false),
            //        id_empresa = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_area", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_area_departamento",
            //            column: x => x.id_departamento,
            //            principalTable: "departamento",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_area_empresa",
            //            column: x => x.id_empresa,
            //            principalTable: "empresa",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "plan_trabajo",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        numero = table.Column<int>(type: "int", nullable: true),
            //        codigo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        id_area = table.Column<int>(type: "int", nullable: true),
            //        id_departamento = table.Column<int>(type: "int", nullable: true),
            //        objetivos = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //        procedimientos = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //        cantidad_personas = table.Column<int>(type: "int", nullable: true),
            //        horas_netas = table.Column<int>(type: "int", nullable: true),
            //        productos = table.Column<int>(type: "int", nullable: true),
            //        fecha_incio_auditoria = table.Column<DateOnly>(type: "date", nullable: true),
            //        fecha_fin_auditoria = table.Column<DateOnly>(type: "date", nullable: true),
            //        id_auditor_asignado = table.Column<int>(type: "int", nullable: true),
            //        id_responsable_area_auditada = table.Column<int>(type: "int", nullable: true),
            //        estado = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
            //        envio_informe = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
            //        fecha_creada = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
            //        id_user_creada = table.Column<int>(type: "int", nullable: true),
            //        activo = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_plan_trabajo", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_plan_trabajo_departamento",
            //            column: x => x.id_departamento,
            //            principalTable: "departamento",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "analisis_riesgo",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        codigo = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: true),
            //        id_area = table.Column<int>(type: "int", nullable: true),
            //        id_riesgo = table.Column<int>(type: "int", nullable: true),
            //        significado = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //        agente_generador = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        causa = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        efecto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
            //        probabilidad = table.Column<int>(type: "int", nullable: false),
            //        impacto = table.Column<int>(type: "int", nullable: false),
            //        resultado = table.Column<int>(type: "int", nullable: false),
            //        nivel_riesgo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
            //        activo = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_analisis_riesgo", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_analisis_riesgo_area",
            //            column: x => x.id_area,
            //            principalTable: "area",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK_analisis_riesgo_riesgo",
            //            column: x => x.id_riesgo,
            //            principalTable: "riesgo",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "plan_trabajo_cronograma",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id_plan_trabajo = table.Column<int>(type: "int", nullable: false),
            //        fecha = table.Column<DateOnly>(type: "date", nullable: false),
            //        cantidad_horas = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_plan_trabajo_cronograma", x => new { x.id, x.id_plan_trabajo });
            //        table.ForeignKey(
            //            name: "FK_plan_trabajo_cronog_plan_trabajo",
            //            column: x => x.id_plan_trabajo,
            //            principalTable: "plan_trabajo",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "plan_trabajo_puntos",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id_plan_trabajo = table.Column<int>(type: "int", nullable: false),
            //        descripcion = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
            //        tipo_punto = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValue: "L", comment: "L : levantamiento - D : descargo"),
            //        activo = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_plan_trabajo_puntos", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_plan_trabajo_puntos_plan_trabajo",
            //            column: x => x.id_plan_trabajo,
            //            principalTable: "plan_trabajo",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_analisis_riesgo_id_area",
            //    table: "analisis_riesgo",
            //    column: "id_area");

            //migrationBuilder.CreateIndex(
            //    name: "IX_analisis_riesgo_id_riesgo",
            //    table: "analisis_riesgo",
            //    column: "id_riesgo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_area_id_departamento",
            //    table: "area",
            //    column: "id_departamento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_area_id_empresa",
            //    table: "area",
            //    column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_departamento_id_empresa",
            //    table: "departamento",
            //    column: "id_empresa");

            //migrationBuilder.CreateIndex(
            //    name: "IX_plan_trabajo_id_auditor_asignado",
            //    table: "plan_trabajo",
            //    column: "id_auditor_asignado");

            //migrationBuilder.CreateIndex(
            //    name: "IX_plan_trabajo_id_departamento",
            //    table: "plan_trabajo",
            //    column: "id_departamento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_plan_trabajo_id_responsable_area_auditada",
            //    table: "plan_trabajo",
            //    column: "id_responsable_area_auditada");

            //migrationBuilder.CreateIndex(
            //    name: "IX_plan_trabajo_cronograma_id_plan_trabajo",
            //    table: "plan_trabajo_cronograma",
            //    column: "id_plan_trabajo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_plan_trabajo_puntos_id_plan_trabajo",
            //    table: "plan_trabajo_puntos",
            //    column: "id_plan_trabajo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "analisis_riesgo");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "plan_trabajo_cronograma");

            //migrationBuilder.DropTable(
            //    name: "plan_trabajo_puntos");

            //migrationBuilder.DropTable(
            //    name: "area");

            //migrationBuilder.DropTable(
            //    name: "riesgo");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "plan_trabajo");

            //migrationBuilder.DropTable(
            //    name: "departamento");

            //migrationBuilder.DropTable(
            //    name: "empresa");
        }
    }
}
