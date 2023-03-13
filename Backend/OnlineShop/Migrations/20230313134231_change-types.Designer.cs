﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Data;

#nullable disable

namespace OnlineShop.Migrations
{
    [DbContext(typeof(OnlineShopeDbContext))]
    [Migration("20230313134231_change-types")]
    partial class changetypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Data.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShowName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Mens_Clothes",
                            ShowName = "لباس مردانه"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Womens_Clothes",
                            ShowName = "لباس زتانه"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Mens_shoes",
                            ShowName = "کفش مردانه"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Wemens_Shoes",
                            ShowName = "کفش زنانه"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Digital_Prodct",
                            ShowName = "محصولات دیجیتالی"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Accesory",
                            ShowName = "لوازم جانبی"
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Data.Models.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("OnlineShop.Data.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Description = "تی شرت مردانه طرح مارشملو",
                            ImagePath = "./Resource/Images/1.jpg",
                            Name = "تی شرت مردانه طرح مارشملو",
                            Price = 40500m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 1L,
                            Description = "تی شرت های نخی فلوریزا همواره از محبوبترین تی شرت ها بوده است و چون با کیفیت جنس بالا (100 درصد نخی پنبه ای و بدون پلی استر) تولیدمی شود همواره طرفداران زیادی دارد. ساده و شیک بودن آن در کنار تنوع در سایز بندی، این نوع تی شرت را همواره به عنوان یکی از محبوبترین کادوها به خصوص در میان مردم مطرح کرده است.این محصول در تمامی سایزهای S، M، L، XL، XXL، XXXL ارائه می گردد. .................................................................................................به سایزبندی تی شرت توجه شود که فقط و فقط مختص پنل فلوریزا می باشد .",
                            ImagePath = "./Resource/Images/2.jpg",
                            Name = "تی شرت مردانه فلوریزا مدل ساده",
                            Price = 37000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 3L,
                            CategoryId = 1L,
                            Description = "تی شرت مردانه",
                            ImagePath = "./Resource/Images/3.jpg",
                            Name = "تی شرت مردانه",
                            Price = 34500m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 4L,
                            CategoryId = 1L,
                            Description = "تیشرت مردانه مدل سرنوشت",
                            ImagePath = "./Resource/Images/4.jpg",
                            Name = "تیشرت مردانه مدل سرنوشت",
                            Price = 35000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 5L,
                            CategoryId = 2L,
                            Description = "تیشرت زنانه",
                            ImagePath = "./Resource/Images/5.jpg",
                            Name = "تیشرت زنانه",
                            Price = 35000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 6L,
                            CategoryId = 3L,
                            Description = "رویه این کفش از جنس پارچه مش می باشد که باعت می شود هوا در داخل کفش جریان پیدا کند و در نتیجه از بو گرفتن پا جلوگیری می کند. زیره این کفش از جنس EVA و لاستیک می باشد که سبب نرمی و راحتی زیاد کفش شده است که در نتیجه در پیاده روی یا رانینگ های طولانی سبب می شود پا کمتر احساس خستگی کند. این کفش مناسب برای پیاده روی و رانینگ های طولانی می باشد و همچنین برای استفاده روزمره نیز مناسب می باشد. زیره لاستیکی که بسیار مقاوم است در برابر سایش سبب افزایش طول عمر کفش می شود",
                            ImagePath = "./Resource/Images/6.jpg",
                            Name = "کفش مخصوص دویدن هوکا",
                            Price = 5800000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 7L,
                            CategoryId = 4L,
                            Description = "این کفش با طرح رنگ چشم نواز دارای متریال و دوخت بسیار با کیفیت است. زیره لاستیکی مورد استفاده در این کفش باعث دوام بالا می گردد. طراحی کفش بگونه ای است که راحتی پای شما را در تمام مدت روز به همراه دارد.",
                            ImagePath = "./Resource/Images/7.jpg",
                            Name = "کفش پیاده روی زنانه مدل Rebound Joy",
                            Price = 9995000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 8L,
                            CategoryId = 4L,
                            Description = "این کفش فوق العاده راحت بوده و راحتی را با یک زیره میانی متمایز EVA و Boost آدیداس افزایش می دهد. رویه این کفش Ripstop آدیداس با روکش های جیر مصنوعی می باشد. زیره لاستیکی برای استیبل بودن و احساس پایداری شما در انواع حرکات ورزشی می باشد.",
                            ImagePath = "./Resource/Images/8.jpg",
                            Name = "کفش پیاده روی زنانه مدل BST ADDS",
                            Price = 9675000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 9L,
                            CategoryId = 5L,
                            Description = "اپل همواره توانسته است گوشی‌های هوشمند قدرتمند و بسیار باکیفیتی را روانه بازار کند و پرچمداران سری 13 هم توانستند با بهره بردن از مشخصات فنی قدرتمند، نه‌تنها به نسبت نسل قبلی یعنی خانواده iPhone12، بلکه به نسبت پرچمداران مدعی دیگر هم عملکرد بسیار درخشانی داشته باشند. iPhone 13 Pro از لحاظ مشخصات فنی در نظر گرفته شده چیزی کم از گل سرسبد این سری یعنی iPhone 13 Pro Max ندارد. در نمای روبه‌رویی این گوشی به صفحه‌نمایش با ابعاد 6.1 اینچ و رزولوشن 2532x1170 از نوع Super Retina XDR OLED مجهز شده است. صفحه‌نمایش بسیار باکیفیت که از جمله قابلیت‌های قدرتمند آن، می‌توانیم به نرخ بروزرسانی 120 هرتز و البته حداکثر روشنایی 1200 نیت (nits) اشاره کنیم. در بخش سنسور‌های دوربین هم قرارگیری سه سنسور با رزولوشن 12 مگاپیکسل به ترتیب از نوع عریض، تله‌فوتو و فوق عریض یا همان ultrawide هستیم که البته سنسور TOF 3D LiDAR هم با عملکردی مشابه با سنسورهای سنجش عمق و البته بهتر، این گوشی را همراه می‌کنند. برای دوربین سلفی هم سنسور با رزولوشن 12 مگاپیکسل در نظر گرفته شده است. در بخش فیلمبرداری هم مثل همیشه این بار اما به لطف توانایی ضبط ویدیو با نهایت کیفیت 4K و سرعت 60 فریم در ثانیه برای سنسور عریض و سلفی، این گوشی عملکرد بی‌نظیری را به شما ارائه می‌کند که کمتر پرچمداری توانایی رقابت با آن را دارد. حضور پردازنده قدرتمند Apple A15 هم سبب شده تا این گوشی به‎‌راحتی از پس اجرای سنگین‌ترین بازی‌های روز دنیا بربیاید. باتری با میزان ظرفیت 3095 میلی‌آمپر‌ساعت دیگر مشخصات در نظر گرفته شده برای این پرچمدار قدرتمند است. البته باید بدانید که خبری از آداپتور شارژر درون جعبه این گوشی نیست.",
                            ImagePath = "./Resource/Images/9.jpg",
                            Name = "گوشی موبایل اپل مدل iPhone 13 Pro AAA",
                            Price = 82900000m,
                            QuantityInStock = 10
                        },
                        new
                        {
                            Id = 10L,
                            CategoryId = 5L,
                            Description = "قاب ونزو مدل Apollo مناسب برای گوشی موبایل شما، با توجه به طراحی مهندسی شده احساس فوق‌العاده ای به وجود می آورد و با داشتن استانداد نظامی سقوط از ارتفاع 3 متر باعث محافظت کامل از گوشی همراه شما می شود. این قاب به گونه ای طراحی شده است که داری ویژگی مقاومت در برابر ضربه به صورت 360 درجه ، محافظ لنزهای دوربین می باشد. همچنین پشت قاب پایه نگهدارنده تعبیه شده است که تماشای فیلم و سریال را برای شما لذت بخش تر می کند. به دلیل جنس و نوع طراحی این قاب شما می توانید به راحتی در هنگام ورزش های سرعتی مثل دوندگی بدون لیز خوردن گوشی حتی در هنگام عرق کردن دست از گوشی خود استفاده کنید.",
                            ImagePath = "./Resource/Images/10.jpg",
                            Name = "کاور ونزو مدل Apollo مناسب برای گوشی موبایل اپل iphone 13 pro",
                            Price = 210000m,
                            QuantityInStock = 10
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1000L);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Gender")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Wallet")
                        .HasColumnType("float");

                    b.Property<string>("ZapCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "تهران",
                            BirthDate = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            FirstName = "ارین",
                            Gender = (short)1,
                            IsAdmin = true,
                            LastName = "بختیاری",
                            MobileNumber = "+989194888834",
                            NationalId = "0025566456",
                            Password = "HccME7tm+bfqvgbjuDtXkTW21iP9w3S9tqAoWdMteCi8PQF3JOzQDOv14bgd6lSfXQepIon6nHl90rDwopUSa1QjA/M=",
                            RegisterDate = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Wallet = 10000000.0,
                            ZapCode = "135649"
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShop.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("OnlineShop.Data.Models.Order", "Order")
                        .WithMany("OrderDatail")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Data.Models.Product", b =>
                {
                    b.HasOne("OnlineShop.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineShop.Data.Models.Order", b =>
                {
                    b.Navigation("OrderDatail");
                });

            modelBuilder.Entity("OnlineShop.Data.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
