# RazorQuizDemo

A minimal ASP.NET Core Razor MVC sample for the cloud service model quiz.

## Files

- `Controllers/QuizController.cs` — controller with GET/POST actions and quiz data.
- `Models/QuizQuestion.cs` — question model.
- `Models/QuizViewModel.cs` — view model for binding answers.
- `Views/Quiz/Index.cshtml` — Razor view that renders the quiz and submit button.

## Usage

1. Add the `RazorQuizDemo` files to an ASP.NET Core MVC project.
2. In `Startup.cs` / `Program.cs`, ensure MVC is enabled:

```csharp
builder.Services.AddControllersWithViews();
```

3. Navigate to `/Quiz` or add a route if using endpoint routing.

4. The view renders the questions and posts selected answers back to the same page.

## Notes

- This sample does not validate or score answers.
- It is meant as a frontend prototype for collecting selections.

## Build & Run (local)

Requirements: .NET 7 SDK

To build and run the app locally from the `RazorQuizDemo` folder:

```bash
dotnet restore
dotnet build
dotnet run --urls "https://localhost:5001;http://localhost:5000"
```

The quiz page will be available at `https://localhost:5001/Quiz`.
