﻿// <auto-generated />
using System;
using ByteShare.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ByteShare.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240806203751_UnitTesting")]
    partial class UnitTesting
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ByteShare.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifierId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifierId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifierId")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.RecipeRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifierId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeRating");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LastModifierId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<int>("FollowersId")
                        .HasColumnType("int");

                    b.Property<int>("FollowsId")
                        .HasColumnType("int");

                    b.HasKey("FollowersId", "FollowsId");

                    b.HasIndex("FollowsId");

                    b.ToTable("UserUser");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("ByteShare.Domain.Entities.User", "Creator")
                        .WithMany("Ingredients")
                        .HasForeignKey("CreatorId");

                    b.HasOne("ByteShare.Domain.Entities.User", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.Navigation("Creator");

                    b.Navigation("LastModifier");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("ByteShare.Domain.Entities.User", "Creator")
                        .WithMany("Recipes")
                        .HasForeignKey("CreatorId");

                    b.HasOne("ByteShare.Domain.Entities.User", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.Navigation("Creator");

                    b.Navigation("LastModifier");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("ByteShare.Domain.Entities.User", "Creator")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("CreatorId");

                    b.HasOne("ByteShare.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ByteShare.Domain.Entities.User", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("ByteShare.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Ingredient");

                    b.Navigation("LastModifier");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.RecipeRating", b =>
                {
                    b.HasOne("ByteShare.Domain.Entities.User", "Creator")
                        .WithMany("RecipeRatings")
                        .HasForeignKey("CreatorId");

                    b.HasOne("ByteShare.Domain.Entities.User", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("ByteShare.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Ratings")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("LastModifier");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.User", b =>
                {
                    b.HasOne("ByteShare.Domain.Entities.User", "Creator")
                        .WithMany("UsersCreated")
                        .HasForeignKey("CreatorId");

                    b.HasOne("ByteShare.Domain.Entities.User", "LastModifier")
                        .WithMany("UsersModified")
                        .HasForeignKey("LastModifierId");

                    b.Navigation("Creator");

                    b.Navigation("LastModifier");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("ByteShare.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ByteShare.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FollowsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("ByteShare.Domain.Entities.User", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("RecipeIngredients");

                    b.Navigation("RecipeRatings");

                    b.Navigation("Recipes");

                    b.Navigation("UsersCreated");

                    b.Navigation("UsersModified");
                });
#pragma warning restore 612, 618
        }
    }
}
