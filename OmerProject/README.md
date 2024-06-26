# OmerProject

OmerProject הוא פרויקט מבוסס ASP.NET Core המנהל משתמשים באמצעות Identity Framework, עם פונקציות של רישום, התחברות, ניהול משתמשים ומעקב אחרי מספר הכניסות לאתר. הפרויקט עושה שימוש ב-SQLite כבסיס נתונים.

## תכולת הפרויקט

### תיקיות וקבצים עיקריים

- **Controllers**
  - `AccountController.cs`: מנהל רישום, התחברות וניתוק משתמשים.
  - `UsersController.cs`: מנהל פעולות CRUD (Create, Read, Update, Delete) על משתמשים רשומים.
  - `HomeController.cs`: מנהל את דף הבית ואת דף הפרטיות.

- **Data**
  - `ApplicationDbContext.cs`: קונטקסט של Entity Framework Core המשמש לניהול בסיס הנתונים.

- **Models**
  - `EditUserViewModel.cs`: מודל לעריכת פרטי משתמש.
  - `RegisterViewModel.cs`: מודל לרישום משתמש חדש.

- **Services**
  - `LoginCounterService.cs`: שירות למעקב אחר מספר הכניסות לאתר.

- **Views**
  - **Account**: מכיל את התצוגות לרישום והתחברות.
  - **Users**: מכיל את התצוגות לניהול משתמשים.
  - **Home**: מכיל את התצוגות לדף הבית ודף הפרטיות.
  - **Shared**: מכיל תצוגות משותפות כמו `_Layout.cshtml`.

- **wwwroot**
  - תיקיה המכילה קבצים סטטיים כמו CSS, JavaScript ותמונות.

- **Program.cs**
  - קובץ אתחול והגדרת שירותים ופריסת האפליקציה.

## מבנה בסיס הנתונים

### טבלאות עיקריות

- **AspNetUsers**: שמירת פרטי המשתמשים.
- **AspNetRoles**: שמירת תפקידי המשתמשים.
- **AspNetUserRoles**: חיבור בין משתמשים לתפקידים.
- **AspNetUserClaims**: שמירת תביעות (claims) של המשתמשים.
- **AspNetRoleClaims**: שמירת תביעות (claims) של התפקידים.
- **AspNetUserLogins**: שמירת פרטי התחברות חיצוניים של המשתמשים.
- **AspNetUserTokens**: שמירת טוקנים (tokens) של המשתמשים.

### אינדקסים

- אינדקסים על עמודות כמו `NormalizedUserName` ו-`NormalizedEmail` להבטחת ייחודיות ושיפור ביצועים.

## תיעוד קריאות בין הדפדפן לשרת ועוגיות בשימוש

### קריאות בין הדפדפן לשרת

#### רישום משתמש חדש

1. **דפדפן:** המשתמש מנווט לעמוד הרישום וממלא את הטופס.
2. **בקשה לשרת:** הדפדפן שולח בקשת POST ל-`/Account/Register` עם נתוני הטופס.
3. **שרת:** בקר ה-`AccountController` מקבל את הבקשה, מאמת את הנתונים ויוצר משתמש חדש.
4. **תשובת שרת:** השרת מחזיר תשובה לדפדפן. אם הרישום הצליח, המשתמש מועבר לדף הבית.

#### התחברות משתמש

1. **דפדפן:** המשתמש מנווט לעמוד ההתחברות וממלא את הטופס.
2. **בקשה לשרת:** הדפדפן שולח בקשת POST ל-`/Account/Login` עם נתוני הטופס.
3. **שרת:** בקר ה-`AccountController` מקבל את הבקשה, מאמת את הנתונים ובודק את זהות המשתמש.
4. **תשובת שרת:** השרת מחזיר תשובה לדפדפן. אם ההתחברות הצליחה, המשתמש מועבר לדף הבית.

### עוגיות בשימוש

#### עוגיות אימות (Authentication Cookies)

ASP.NET Core Identity משתמש בעוגיות לצורך אימות והתחברות המשתמשים. להלן העוגיות העיקריות בשימוש:

- **.AspNetCore.Identity.Application**
  - **מטרה:** ניהול מצב התחברות המשתמש.
  - **תכולה:** מכילה פרטי אימות מוצפנים של המשתמש.
  - **משך זמן:** תקופת הזמן שבה המשתמש נשאר מחובר תלויה בהגדרות ההתחברות (זמני ברירת המחדל או במידה והמשתמש בחר באופציה "Remember Me").

- **.AspNetCore.Identity.External**
  - **מטרה:** ניהול התחברות חיצונית (למשל, דרך ספקים כמו Google, Facebook).
  - **תכולה:** מכילה פרטי התחברות מוצפנים לשירות החיצוני.
  - **משך זמן:** זמני ברירת המחדל, נמחקת לאחר סיום תהליך ההתחברות החיצונית.

#### עוגיות ניהול מצב (Anti-Forgery Cookies)

ASP.NET Core משתמש בעוגיות למניעת התקפות CSRF (Cross-Site Request Forgery). העוגיות העיקריות הן:

- **.AspNetCore.Antiforgery.<random>**
  - **מטרה:** למניעת התקפות CSRF.
  - **תכולה:** מכילה ערך Anti-Forgery Token המשמש לאימות בקשות POST.
  - **משך זמן:** עד סיום הסשן של הדפדפן.

## תיעוד תצוגות

### תצוגות בתיקיית Account

#### Register.cshtml

##### תיאור

תצוגת רישום המשתמש החדש. מכילה טופס המאפשר למשתמש להירשם לאתר.

#### Login.cshtml

##### תיאור

תצוגת התחברות המשתמש. מכילה טופס המאפשר למשתמש להתחבר לאתר.

### תצוגות בתיקיית Users

#### Index.cshtml

##### תיאור

תצוגת רשימת המשתמשים. מציגה את כל המשתמשים הרשומים במערכת.

#### Details.cshtml

##### תיאור

תצוגת פרטי משתמש ספציפי. מציגה את הפרטים של משתמש לפי מזהה.

#### Create.cshtml

##### תיאור

תצוגת יצירת משתמש חדש. מכילה טופס המאפשר למנהל ליצור משתמש חדש.

#### Edit.cshtml

##### תיאור

תצוגת עריכת פרטי משתמש. מכילה טופס המאפשר למנהל לערוך פרטים של משתמש קיים.

#### Delete.cshtml

##### תיאור

תצוגת מחיקת משתמש. מכילה אישור מחיקה של משתמש קיים.

### תצוגות בתיקיית Home

#### Index.cshtml

##### תיאור

תצוגת דף הבית. מציגה ברכת שלום למשתמש ומספר הכניסות לאתר.

#### Privacy.cshtml

##### תיאור

תצוגת דף הפרטיות. מציגה מידע על מדיניות הפרטיות של האתר.

### תצוגות בתיקיית Shared

#### _Layout.cshtml

##### תיאור

תצוגת ה-Layout הראשית של האתר. מכילה את תבנית העיצוב הכללית של האתר ומכילה את הניווט העליון, התוכן המרכזי והפוטר.

#### _ValidationScriptsPartial.cshtml

##### תיאור

תצוגה חלקית המכילה סקריפטים לניהול ולידציה של הטפסים
---

### קרדיטים

פרויקט זה נעשה על ידי עומר קרקובסקי מכיתה י׳ 7 בבית הספר יוענה ז׳בוטינסקי בשנת הלימודים תשפ״ד.
