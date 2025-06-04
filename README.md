# eCommerceApi

Aplikacja Web API stworzona w .NET Core, która pozwala na zarządzanie produktami i zamówieniami w systemie e-commerce.

## CI/CD - Automatyzacja budowania

Projekt korzysta z GitHub Actions do automatyzacji procesu budowania aplikacji

### Workflow:
- **Uruchamia się po każdym pushu na gałąź `main`**.
- **Kroki workflow**:

  1 Sprawdzenie repozytorium
  
  2 Przywrócenie zależności
  
  3 Budowanie aplikacji
  
  4 Publikowanie aplikacji
  
## Jak połączyć się z wdrożoną aplikacją

Aplikacja jest dostępna pod publicznym adresem:  
**[Link do aplikacji na Azure](ecommerce-api-apgbb2erbbbpexd2.polandcentral-01.azurewebsites.net)**  
Możesz korzystać z aplikacji, wykonując zapytania HTTP do odpowiednich **endpointów**. Lista dostępnych endpointów jest udostępniona w dokumentacji **Swagger**, dostępnej pod adresem:  
**[Swagger UI]([ecommerce-api-apgbb2erbbbpexd2.polandcentral-01.azurewebsites.net/swagger](https://ecommerce-api-apgbb2erbbbpexd2.polandcentral-01.azurewebsites.net/swagger)](https://ecommerce-api-apgbb2erbbbpexd2.polandcentral-01.azurewebsites.net/swagger/index.html))**.

## Usługi Azure wykorzystane w projekcie

- **Azure Web App**: Użyto usługi **Azure App Service**, aby hostować aplikację ASP.NET Core API w chmurze.
- **Azure SQL Database**: Baza danych dla aplikacji została utworzona jako **SQL Server** w chmurze, służąca do przechowywania danych aplikacji, takich jak produkty i zamówienia.
