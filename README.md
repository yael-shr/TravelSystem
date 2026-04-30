# TravelSystem - Student Location Monitoring 

מערכת לניטור וניהול מיקומי תלמידות בזמן אמת, הכוללת ממשק מורה לניהול כיתתי וממשק הורים לצפייה במיקום.

## פיצ'רים עיקריים
*   **ממשק מורה**: צפייה בכל תלמידות הכיתה על גבי מפת Google Maps ועדכון מיקומים אוטומטי.
*   **ממשק הורה**: מעקב ממוקד אחרי תלמידה ספציפית.
*   **ניהול נתונים**: הוספת תלמידות חדשות ושיוכן לכיתה הרלוונטית.
*   **שלב בונוס - Proximity Alerts**: מערכת התראות חכמה המחשבת את המרחק בין המורה לתלמידותיה ומתריעה בזמן אמת על חריגה מהטווח המוגדר (Geofencing).

## טכנולוגיות
*   **Frontend**: Angular 17+, Google Maps API, Signals, RxJS.
*   **Backend**: .NET Core Web API, Entity Framework Core.
*   **Database**: SQL Server.
*   **Architecture**: Repository Pattern & Service Layer (Dependency Injection).

##הוראות הרצה

### דרישות קדם
*   .NET SDK 8.0+
*   Node.js & Angular CLI
*   SQL Server

### Backend
1. נווט לתיקיית ה-Server.
2. עדכן את מחרוזת החיבור (ConnectionString) ב-`appsettings.json`.
3. הרץ פקודת `Update-Database` בתוך ה-Package Manager Console.
4. הפעל את השרת:
   ```bash
   dotnet run
     ```

   ### Frontend
1. נווט לתיקיית ה-Client.
2. התקן את חבילות ה-NPM הנדרשות:
   ```bash
   npm install
   ```
3. ודא שקיים מפתח API תקין של Google Maps בקובץ ה- environments.ts`.
4. הפעל את אפליקציית ה-Angular:
   ```bash
   ng serve

   5. פתח את הדפדפן בכתובת: `http://localhost:4200`.

## מבנה הפרויקט
*   **TravelSystem**: חשיפת ה-Endpoints וניהול ה-Controllers.
*   **TravelSystem.Services**: שכבת הלוגיקה העסקית, כולל מימוש ה-Service, הזרקת תלויות (DI) וחישובי מרחק גיאוגרפיים.
*   **TravelSystem.Repositories**: שכבת הגישה לנתונים (Data Access) המשתמשת ב-Entity Framework Core.
*   **TravelSystem.Entities**: הגדרת הישויות, ה-DTOs (Data Transfer Objects) והממשקים (Interfaces).

## לוגיקה מרכזית - שלב הבונוס
במערכת הוטמעה נוסחת **Haversine** לחישוב מרחק אווירי בין שתי נקודות על גבי כדור הארץ. המערכת מבצעת "דגימה" (Polling) כל 30-60 שניות ומבצעת השוואה בין קואורדינטות המורה (המתקבלות מהדפדפן) לבין קואורדינטות התלמידות. במידה וזוהתה חריגה מהרדיוס המוגדר, המערכת מקפיצה התראה ויזואלית למורה.

---
