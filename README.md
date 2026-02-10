# Equipment Management System

This project is a full-stack equipment management application built with:

- Backend: ASP.NET Core Web API
- Frontend: Angular (Standalone Components)

## Features

- View all equipment items
- Add new equipment
- Edit existing equipment
- Delete equipment
- RESTful API with full CRUD support

## Backend Notes

The backend uses **in-memory storage** as required.
No database setup is needed.

### API Base URL

The frontend expects the backend API to run under:

https://localhost:64156/api

If the backend runs on a different port, update:

src/environments/environment.ts

```ts
apiBaseUrl: 'https://localhost:XXXX/api'
