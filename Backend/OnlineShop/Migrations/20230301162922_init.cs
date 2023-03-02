using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: false),
                    ZapCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wallet = table.Column<double>(type: "float", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsFinaly = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderId1 = table.Column<long>(type: "bigint", nullable: true),
                    ProductId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ShowName" },
                values: new object[,]
                {
                    { 1L, "Mens_Clothes", "لباس مردانه" },
                    { 2L, "Womens_Clothes", "لباس زتانه" },
                    { 3L, "Mens_shoes", "کفش مردانه" },
                    { 4L, "Wemens_Shoes", "کفش زنانه" },
                    { 5L, "Digital_Prodct", "محصولات دیجیتالی" },
                    { 6L, "Accesory", "لوازم جانبی" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BirthDate", "Email", "FirstName", "Gender", "IsAdmin", "LastName", "MobileNumber", "NationalId", "Password", "RegisterDate", "Wallet", "ZapCode" },
                values: new object[] { 1L, "تهران", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "ارین", (short)1, true, "بختیاری", "+989194888834", "0025566456", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000000.0, "135649" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1L, 1L, "تی شرت مردانه طرح مارشملو", "./Resource/Images/1.jpg", "تی شرت مردانه طرح مارشملو", 40500m, 10 },
                    { 2L, 1L, "تی شرت های نخی فلوریزا همواره از محبوبترین تی شرت ها بوده است و چون با کیفیت جنس بالا (100 درصد نخی پنبه ای و بدون پلی استر) تولیدمی شود همواره طرفداران زیادی دارد. ساده و شیک بودن آن در کنار تنوع در سایز بندی، این نوع تی شرت را همواره به عنوان یکی از محبوبترین کادوها به خصوص در میان مردم مطرح کرده است.این محصول در تمامی سایزهای S، M، L، XL، XXL، XXXL ارائه می گردد. .................................................................................................به سایزبندی تی شرت توجه شود که فقط و فقط مختص پنل فلوریزا می باشد .", "./Resource/Images/2.jpg", "تی شرت مردانه فلوریزا مدل ساده", 37000m, 10 },
                    { 3L, 1L, "تی شرت مردانه", "./Resource/Images/3.jpg", "تی شرت مردانه", 34500m, 10 },
                    { 4L, 1L, "تیشرت مردانه مدل سرنوشت", "./Resource/Images/4.jpg", "تیشرت مردانه مدل سرنوشت", 35000m, 10 },
                    { 5L, 2L, "تیشرت زنانه", "./Resource/Images/5.jpg", "تیشرت زنانه", 35000m, 10 },
                    { 6L, 3L, "رویه این کفش از جنس پارچه مش می باشد که باعت می شود هوا در داخل کفش جریان پیدا کند و در نتیجه از بو گرفتن پا جلوگیری می کند. زیره این کفش از جنس EVA و لاستیک می باشد که سبب نرمی و راحتی زیاد کفش شده است که در نتیجه در پیاده روی یا رانینگ های طولانی سبب می شود پا کمتر احساس خستگی کند. این کفش مناسب برای پیاده روی و رانینگ های طولانی می باشد و همچنین برای استفاده روزمره نیز مناسب می باشد. زیره لاستیکی که بسیار مقاوم است در برابر سایش سبب افزایش طول عمر کفش می شود", "./Resource/Images/6.jpg", "کفش مخصوص دویدن هوکا", 5800000m, 10 },
                    { 7L, 4L, "این کفش با طرح رنگ چشم نواز دارای متریال و دوخت بسیار با کیفیت است. زیره لاستیکی مورد استفاده در این کفش باعث دوام بالا می گردد. طراحی کفش بگونه ای است که راحتی پای شما را در تمام مدت روز به همراه دارد.", "./Resource/Images/7.jpg", "کفش پیاده روی زنانه مدل Rebound Joy", 9995000m, 10 },
                    { 8L, 4L, "این کفش فوق العاده راحت بوده و راحتی را با یک زیره میانی متمایز EVA و Boost آدیداس افزایش می دهد. رویه این کفش Ripstop آدیداس با روکش های جیر مصنوعی می باشد. زیره لاستیکی برای استیبل بودن و احساس پایداری شما در انواع حرکات ورزشی می باشد.", "./Resource/Images/8.jpg", "کفش پیاده روی زنانه مدل BST ADDS", 9675000m, 10 },
                    { 9L, 5L, "اپل همواره توانسته است گوشی‌های هوشمند قدرتمند و بسیار باکیفیتی را روانه بازار کند و پرچمداران سری 13 هم توانستند با بهره بردن از مشخصات فنی قدرتمند، نه‌تنها به نسبت نسل قبلی یعنی خانواده iPhone12، بلکه به نسبت پرچمداران مدعی دیگر هم عملکرد بسیار درخشانی داشته باشند. iPhone 13 Pro از لحاظ مشخصات فنی در نظر گرفته شده چیزی کم از گل سرسبد این سری یعنی iPhone 13 Pro Max ندارد. در نمای روبه‌رویی این گوشی به صفحه‌نمایش با ابعاد 6.1 اینچ و رزولوشن 2532x1170 از نوع Super Retina XDR OLED مجهز شده است. صفحه‌نمایش بسیار باکیفیت که از جمله قابلیت‌های قدرتمند آن، می‌توانیم به نرخ بروزرسانی 120 هرتز و البته حداکثر روشنایی 1200 نیت (nits) اشاره کنیم. در بخش سنسور‌های دوربین هم قرارگیری سه سنسور با رزولوشن 12 مگاپیکسل به ترتیب از نوع عریض، تله‌فوتو و فوق عریض یا همان ultrawide هستیم که البته سنسور TOF 3D LiDAR هم با عملکردی مشابه با سنسورهای سنجش عمق و البته بهتر، این گوشی را همراه می‌کنند. برای دوربین سلفی هم سنسور با رزولوشن 12 مگاپیکسل در نظر گرفته شده است. در بخش فیلمبرداری هم مثل همیشه این بار اما به لطف توانایی ضبط ویدیو با نهایت کیفیت 4K و سرعت 60 فریم در ثانیه برای سنسور عریض و سلفی، این گوشی عملکرد بی‌نظیری را به شما ارائه می‌کند که کمتر پرچمداری توانایی رقابت با آن را دارد. حضور پردازنده قدرتمند Apple A15 هم سبب شده تا این گوشی به‎‌راحتی از پس اجرای سنگین‌ترین بازی‌های روز دنیا بربیاید. باتری با میزان ظرفیت 3095 میلی‌آمپر‌ساعت دیگر مشخصات در نظر گرفته شده برای این پرچمدار قدرتمند است. البته باید بدانید که خبری از آداپتور شارژر درون جعبه این گوشی نیست.", "./Resource/Images/9.jpg", "گوشی موبایل اپل مدل iPhone 13 Pro AAA", 82900000m, 10 },
                    { 10L, 5L, "قاب ونزو مدل Apollo مناسب برای گوشی موبایل شما، با توجه به طراحی مهندسی شده احساس فوق‌العاده ای به وجود می آورد و با داشتن استانداد نظامی سقوط از ارتفاع 3 متر باعث محافظت کامل از گوشی همراه شما می شود. این قاب به گونه ای طراحی شده است که داری ویژگی مقاومت در برابر ضربه به صورت 360 درجه ، محافظ لنزهای دوربین می باشد. همچنین پشت قاب پایه نگهدارنده تعبیه شده است که تماشای فیلم و سریال را برای شما لذت بخش تر می کند. به دلیل جنس و نوع طراحی این قاب شما می توانید به راحتی در هنگام ورزش های سرعتی مثل دوندگی بدون لیز خوردن گوشی حتی در هنگام عرق کردن دست از گوشی خود استفاده کنید.", "./Resource/Images/10.jpg", "کاور ونزو مدل Apollo مناسب برای گوشی موبایل اپل iphone 13 pro", 210000m, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId1",
                table: "OrderDetails",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId1",
                table: "OrderDetails",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
