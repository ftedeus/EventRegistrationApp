## 🎫 Event Registration Blazor WebAssembly App
A modern **Blazor WebAssembly** application for managing event registrations, automatically deployed to **Azure App Service** using GitHub Actions.
GitHub Actions workflow for continuous integration and deployment (CI/CD)  
---
![Build Status](https://github.com/ftedeus/EventRegistrationApp/actions/workflows/deploy.yml/badge.svg)
![Deployment](https://img.shields.io/github/deployments/ftedeus/EventRegistrationApp/Production?label=deployed)
![Last Commit](https://img.shields.io/github/last-commit/ftedeus/EventRegistrationApp)
![Issues](https://img.shields.io/github/issues/ftedeus/EventRegistrationApp)
![Pull Requests](https://img.shields.io/github/issues-pr/ftedeus/EventRegistrationApp)


---

## 🚀 Features

- Client-side Blazor WebAssembly (WASM) front-end
- Built with .NET 8
- CI/CD using GitHub Actions
- Azure App Service deployment via Service Principal
- Unit testing integrated in pipeline

---

## 🛠 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Azure Subscription and App Service
- GitHub repository secrets configured:
  - `AZURE_CREDENTIALS`: Service Principal JSON from `az ad sp create-for-rbac --sdk-auth`


## ⚙️ CI/CD Pipeline

Workflow: [deploy.yml](.github/workflows/deploy.yml)

### On push to `main`, it:

1. Restores dependencies
2. Builds and tests the app
3. Publishes the Blazor output
4. Authenticates with Azure via Service Principal
5. Deploys to [Azure App Service](https://portal.azure.com/)


## 🧪 Run Locally

```bash
dotnet restore
dotnet build
dotnet run --project EventRegistrationApp.csproj
```

## Setup Instructions

1. Create a Service Principal with the following Azure CLI command:

   az ad sp create-for-rbac --name "github-deployer" --role contributor --scopes /subscriptions/<SUBSCRIPTION_ID>/resourceGroups/<RESOURCE_GROUP> --sdk-auth

2. Copy the JSON output and add it as a GitHub secret named AZURE_CREDENTIALS in your repository settings.

3. Replace the app-name value in the workflow file with your Azure App Service name.

4. Push changes to the main branch to trigger the CI/CD pipeline.


## License
This project is licensed under the MIT License.

Contact
For questions or contributions, please open an issue or submit a pull request.

 
