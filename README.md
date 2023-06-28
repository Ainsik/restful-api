# Simple RESTful API

This is a simple RESTful API implementation that provides basic functionality for managing resources. The API allows users to perform CRUD operations (Create, Read, Update, Delete) on a set of resources using HTTP methods.

## Getting Started

To get started with this API, follow the instructions below:

### Prerequisites

- Node.js
- Node Package Manager

### Installation

1. Clone the repository:

```
git clone git@github.com:Ainsik/restful-api.git
```

2. Navigate to the project directory:

```
cd simple-restful-api
```

3. Install the dependencies:

```
npm install
```

4. Start the API server:

```
npm run serve
```

The API server should now be running on `http://localhost:3000`.

## API Endpoints

The following endpoints are available in this API:

### `GET /api/doctors`

Fetches all doctors.

### `GET /api/doctors/:id`

Fetches a specific doctor by ID.

### `POST /api/doctors`

Creates a new doctor.

### `PUT /api/doctors/:id`

Updates a specific doctor by ID.

### `DELETE /api/doctors/:id`

Deletes a specific doctor by ID.

## Conclusion

This simple RESTful API provides a basic foundation for managing resources using standard HTTP methods. Feel free to explore and extend it according to your needs. For more information and customization options, refer to the project documentation and the source code.
