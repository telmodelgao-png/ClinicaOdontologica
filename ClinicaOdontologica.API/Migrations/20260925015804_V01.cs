using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaOdontologica.API.Migrations
{
    /// <inheritdoc />
    public partial class V01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    id_consultorio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_sala = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    piso = table.Column<int>(type: "integer", nullable: false),
                    equipamiento_principal = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.id_consultorio);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    id_especialidad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_especialidad = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.id_especialidad);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    nombres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    telefono = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.id_paciente);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    id_tratamiento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_tratamiento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    costo_base = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Duracion_estimada_minutos = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.id_tratamiento);
                });

            migrationBuilder.CreateTable(
                name: "Odontologos",
                columns: table => new
                {
                    Id_odontologo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    registro_medico = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_especialidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontologos", x => x.Id_odontologo);
                    table.ForeignKey(
                        name: "FK_Odontologos_Especialidades_id_especialidad",
                        column: x => x.id_especialidad,
                        principalTable: "Especialidades",
                        principalColumn: "id_especialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historialesmedicos",
                columns: table => new
                {
                    id_historialMedico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alergias = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    enfermedades_previas = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    tipo_sangre = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    id_paciente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historialesmedicos", x => x.id_historialMedico);
                    table.ForeignKey(
                        name: "FK_Historialesmedicos_Pacientes_id_paciente",
                        column: x => x.id_paciente,
                        principalTable: "Pacientes",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    id_cita = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha_cita = table.Column<DateTime>(type: "timestamp", nullable: false),
                    motivo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    id_paciemte = table.Column<int>(type: "integer", nullable: false),
                    id_odontologo = table.Column<int>(type: "integer", nullable: false),
                    id_consultorio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citas", x => x.id_cita);
                    table.ForeignKey(
                        name: "FK_citas_Consultorios_id_consultorio",
                        column: x => x.id_consultorio,
                        principalTable: "Consultorios",
                        principalColumn: "id_consultorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citas_Odontologos_id_odontologo",
                        column: x => x.id_odontologo,
                        principalTable: "Odontologos",
                        principalColumn: "Id_odontologo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citas_Pacientes_id_paciemte",
                        column: x => x.id_paciemte,
                        principalTable: "Pacientes",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detallesCitas",
                columns: table => new
                {
                    id_detalle = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    costo_aplicado = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    observaciones = table.Column<string>(type: "text", nullable: false),
                    id_cita = table.Column<int>(type: "integer", nullable: false),
                    id_tratamiento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallesCitas", x => x.id_detalle);
                    table.ForeignKey(
                        name: "FK_detallesCitas_Tratamientos_id_tratamiento",
                        column: x => x.id_tratamiento,
                        principalTable: "Tratamientos",
                        principalColumn: "id_tratamiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallesCitas_citas_id_cita",
                        column: x => x.id_cita,
                        principalTable: "citas",
                        principalColumn: "id_cita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    id_factura = table.Column<string>(type: "text", nullable: false),
                    fecha_emision = table.Column<DateTime>(type: "timestamp", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    impuestos = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    estado_pago = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_cita = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.id_factura);
                    table.ForeignKey(
                        name: "FK_Facturas_citas_id_cita",
                        column: x => x.id_cita,
                        principalTable: "citas",
                        principalColumn: "id_cita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recetas",
                columns: table => new
                {
                    id_recetas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha_emision = table.Column<DateTime>(type: "timestamp", nullable: false),
                    indicaciones = table.Column<string>(type: "text", nullable: false),
                    id_cita = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recetas", x => x.id_recetas);
                    table.ForeignKey(
                        name: "FK_recetas_citas_id_cita",
                        column: x => x.id_cita,
                        principalTable: "citas",
                        principalColumn: "id_cita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_citas_id_consultorio",
                table: "citas",
                column: "id_consultorio");

            migrationBuilder.CreateIndex(
                name: "IX_citas_id_odontologo",
                table: "citas",
                column: "id_odontologo");

            migrationBuilder.CreateIndex(
                name: "IX_citas_id_paciemte",
                table: "citas",
                column: "id_paciemte");

            migrationBuilder.CreateIndex(
                name: "IX_detallesCitas_id_cita",
                table: "detallesCitas",
                column: "id_cita");

            migrationBuilder.CreateIndex(
                name: "IX_detallesCitas_id_tratamiento",
                table: "detallesCitas",
                column: "id_tratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_id_cita",
                table: "Facturas",
                column: "id_cita");

            migrationBuilder.CreateIndex(
                name: "IX_Historialesmedicos_id_paciente",
                table: "Historialesmedicos",
                column: "id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Odontologos_id_especialidad",
                table: "Odontologos",
                column: "id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_recetas_id_cita",
                table: "recetas",
                column: "id_cita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallesCitas");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Historialesmedicos");

            migrationBuilder.DropTable(
                name: "recetas");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Odontologos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
