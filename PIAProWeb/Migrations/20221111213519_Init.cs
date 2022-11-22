using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIAProWeb.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Calle_Numero = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Codigo_Postal = table.Column<int>(type: "int", nullable: true),
                    Referencias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Categoria_Producto",
                columns: table => new
                {
                    Id_categoria = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__4A033A932CE71C3D", x => x.Id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Datos_Tarjeta",
                columns: table => new
                {
                    Id_Tarjeta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    Numero_Tarjeta = table.Column<int>(type: "int", nullable: false),
                    Nombre_Propietario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha_Vencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero_Seguridad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Datos_Ta__F5762032B459290D", x => x.Id_Tarjeta);
                    table.ForeignKey(
                        name: "FK_Datos_Tarjeta_Usuarios",
                        column: x => x.Id_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    Id_Orden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    Fecha_Orden = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orden__370733B6E70FCB69", x => x.Id_Orden);
                    table.ForeignKey(
                        name: "FK_Orden_Usuarios",
                        column: x => x.Id_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Categoria = table.Column<int>(type: "int", nullable: false),
                    Nombre_Producto = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Precio_Producto = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Imagen_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock_Producto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__2085A9CF821D5EDD", x => x.Id_Producto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_Producto",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria_Producto",
                        principalColumn: "Id_categoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Id_Producto = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carrito__5B65BF975107183C", x => new { x.IdUsuario, x.Id_Producto });
                    table.ForeignKey(
                        name: "FK_Carrito_Producto1",
                        column: x => x.Id_Producto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto");
                    table.ForeignKey(
                        name: "FK_Carrito_Usuarios",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Orden",
                columns: table => new
                {
                    Id_Orden = table.Column<int>(type: "int", nullable: false),
                    Id_Articulo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Detalle___370733B6C49303A3", x => new { x.Id_Orden, x.Id_Articulo });
                    table.ForeignKey(
                        name: "FK_Detalle_Orden_Orden",
                        column: x => x.Id_Orden,
                        principalTable: "Orden",
                        principalColumn: "Id_Orden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Orden_Producto",
                        column: x => x.Id_Articulo,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especs_CPU",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Arquitectura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Generacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Velocidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nucleos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grafico_Integrados = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Frecuencia_de_Graficos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TDP = table.Column<int>(type: "int", nullable: false),
                    Disipador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especs_C__09889210ECD857D0", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Especs_CPU_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especs_discoduro",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Tipo_Disco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Interfaz = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Velocidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especs_d__098892101F57B502", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Especs_discoduro_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especs_Fuente_Alimentacion",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Maxima_Potencia = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ventilador = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Conector = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Conectores_SATA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Entrada_Voltaje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especs_F__09889210980AD2C9", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Especs_Fuente_Alimentacion_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especs_Graficas",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CUDA_Cores = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Memoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo_Memoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Frecuencia_Memoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DirectX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Interfaz = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salidas_Video = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especs_G__098892103BF442AA", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Especs_Graficas_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especs_PlacaMadre",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Marca_Proceesador = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Procesador_Compatibles = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Modelo_Chipset = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo_MemoriaDDR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ranuras_Memoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Maxima_Memoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Arquitectura_Memoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo_Ranura_Expansion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Entradas_Almacenamiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ENtradas_Video = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Chipset_Audio = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Puerto_Red = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Puertos_Usb_traseros = table.Column<int>(type: "int", nullable: false),
                    Puertos_HDMI_traseros = table.Column<int>(type: "int", nullable: false),
                    Puertos_DisplayPort_traseros = table.Column<int>(type: "int", nullable: false),
                    Puertos_red_traseros = table.Column<int>(type: "int", nullable: false),
                    Puertos_audio_traseros = table.Column<int>(type: "int", nullable: false),
                    Conector_24pin_Interno = table.Column<int>(type: "int", nullable: false),
                    Conector_12v8pin_Interno = table.Column<int>(type: "int", nullable: false),
                    Conector_Sata_Interno = table.Column<int>(type: "int", nullable: false),
                    Conector_M2_Interno = table.Column<int>(type: "int", nullable: false),
                    Conector_cpufan_Interno = table.Column<int>(type: "int", nullable: false),
                    Conector_tpm_Interno = table.Column<int>(type: "int", nullable: false),
                    Especificacion_Extra = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especs_P__098892101E962375", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Especs_PlacaMadre_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especs_ram",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Velocidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tecnologia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voltaje_Alimentacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especs_r__09889210C637BAF8", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Especs_ram_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_Id_Producto",
                table: "Carrito",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "UQ__Categori__75E3EFCFF18DD025",
                table: "Categoria_Producto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Datos_Tarjeta_Id_Usuario",
                table: "Datos_Tarjeta",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Orden_Id_Articulo",
                table: "Detalle_Orden",
                column: "Id_Articulo");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_Id_Usuario",
                table: "Orden",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Id_Categoria",
                table: "Producto",
                column: "Id_Categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Datos_Tarjeta");

            migrationBuilder.DropTable(
                name: "Detalle_Orden");

            migrationBuilder.DropTable(
                name: "Especs_CPU");

            migrationBuilder.DropTable(
                name: "Especs_discoduro");

            migrationBuilder.DropTable(
                name: "Especs_Fuente_Alimentacion");

            migrationBuilder.DropTable(
                name: "Especs_Graficas");

            migrationBuilder.DropTable(
                name: "Especs_PlacaMadre");

            migrationBuilder.DropTable(
                name: "Especs_ram");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categoria_Producto");
        }
    }
}
