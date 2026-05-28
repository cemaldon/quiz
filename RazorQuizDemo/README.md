# RazorQuizDemo

A minimal ASP.NET Core Razor app for the cloud service model quiz.

## Structure

- `RazorQuizDemo/Controllers/QuizController.cs` — MVC controller with GET/POST actions.
- `RazorQuizDemo/Controllers/QuizApiController.cs` — JSON API for quiz questions and submission.
- `RazorQuizCore/Models` — shared model classes used by both the app and the UI library.
- `RazorQuizUI/Views/Quiz/Index.cshtml` — Razor Class Library view for the quiz UI.

## Usage

1. Open the app project in `RazorQuizDemo`.
2. Make sure the project references `RazorQuizUI` and `RazorQuizCore`.
3. Start the app and navigate to `/Quiz`.
4. The API endpoint is available at `/api/quiz`.

## Notes

- The sample now includes EF Core migrations and SQLite persistence.
- Sample quiz questions are seeded on first run.
- The UI is served from the Razor Class Library.

## Build & Run (local)

Requirements: .NET 8 SDK

From the workspace root or `RazorQuizDemo` folder:

```bash
cd RazorQuizDemo
dotnet restore
dotnet build
```

To apply database migrations:

```bash
dotnet ef database update
```

To run the app:

```bash
dotnet run --urls "http://localhost:5000"
```

The quiz page will be available at `http://localhost:5000/Quiz`.
The API endpoint will be available at `http://localhost:5000/api/quiz`.
