// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace YarikAndCo.Migrations
{
    [DbContext(typeof(FurnitureStoreContext))]
    [Migration("20220603065446_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Carpenter", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("seniority")
                        .HasColumnType("integer")
                        .HasColumnName("seniority");

                    b.HasKey("id")
                        .HasName("pk_carpenters");

                    b.ToTable("carpenters", (string)null);
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("id")
                        .HasName("pk_clients");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("Driver", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("seniority")
                        .HasColumnType("integer")
                        .HasColumnName("seniority");

                    b.HasKey("id")
                        .HasName("pk_drivers");

                    b.ToTable("drivers", (string)null);
                });

            modelBuilder.Entity("Furniture", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("aboutText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("about_text");

                    b.Property<string>("furnitureName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("furniture_name");

                    b.Property<string>("imageLink1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_link1");

                    b.Property<string>("imageLink2")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_link2");

                    b.Property<string>("imageLink3")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_link3");

                    b.Property<string>("imageLink4")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_link4");

                    b.Property<int>("oldPrice")
                        .HasColumnType("integer")
                        .HasColumnName("old_price");

                    b.Property<int>("price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.Property<string>("roomType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("room_type");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("id")
                        .HasName("pk_furnitures");

                    b.ToTable("furnitures", (string)null);
                });

            modelBuilder.Entity("FurnitureOrder", b =>
                {
                    b.Property<int>("furnituresid")
                        .HasColumnType("integer")
                        .HasColumnName("furnituresid");

                    b.Property<int>("ordersid")
                        .HasColumnType("integer")
                        .HasColumnName("ordersid");

                    b.HasKey("furnituresid", "ordersid")
                        .HasName("pk_furniture_order");

                    b.HasIndex("ordersid")
                        .HasDatabaseName("ix_furniture_order_ordersid");

                    b.ToTable("furniture_order", (string)null);
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("carpenterid")
                        .HasColumnType("integer")
                        .HasColumnName("carpenterid");

                    b.Property<int>("clientid")
                        .HasColumnType("integer")
                        .HasColumnName("clientid");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("destination");

                    b.Property<int>("driverid")
                        .HasColumnType("integer")
                        .HasColumnName("driverid");

                    b.HasKey("id")
                        .HasName("pk_orders");

                    b.HasIndex("carpenterid")
                        .HasDatabaseName("ix_orders_carpenterid");

                    b.HasIndex("clientid")
                        .HasDatabaseName("ix_orders_clientid");

                    b.HasIndex("driverid")
                        .HasDatabaseName("ix_orders_driverid");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("FurnitureOrder", b =>
                {
                    b.HasOne("Furniture", null)
                        .WithMany()
                        .HasForeignKey("furnituresid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_furniture_order_furnitures_furnituresid");

                    b.HasOne("Order", null)
                        .WithMany()
                        .HasForeignKey("ordersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_furniture_order_orders_ordersid");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("Carpenter", "carpenter")
                        .WithMany("orders")
                        .HasForeignKey("carpenterid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_carpenters_carpenterid");

                    b.HasOne("Client", "client")
                        .WithMany("orders")
                        .HasForeignKey("clientid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_clients_clientid");

                    b.HasOne("Driver", "driver")
                        .WithMany("orders")
                        .HasForeignKey("driverid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_drivers_driverid");

                    b.Navigation("carpenter");

                    b.Navigation("client");

                    b.Navigation("driver");
                });

            modelBuilder.Entity("Carpenter", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Driver", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
