# eCommerceApi

Aplikacja Web API stworzona w .NET Core, która pozwala na zarządzanie produktami i zamówieniami w systemie e-commerce.

## CI/CD - Automatyzacja budowania

Projekt korzysta z GitHub Actions do automatyzacji procesu budowania aplikacji

### Workflow:
- **Uruchamia się po każdym pushu na gałąź `main`**.
- **Kroki workflow**:
  1. Sprawdzenie repozytorium
  2. Przywrócenie zależności
  3. Budowanie aplikacji
  4. Publikowanie aplikacji
