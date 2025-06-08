# JWT Authentication

A simple project demonstrating how to implement JSON Web Token (JWT) authentication in a modern web application. This repository provides a practical example of secure user authentication, token generation, and protected routes using JWT.

## Features

- User registration and login
- Secure password storage
- JWT generation and verification
- Middleware for protecting routes
- Logout and token invalidation

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/ngothanhdat-AK/JWT-Authentication.git
   cd JWT-Authentication
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```
   or
   ```bash
   yarn install
   ```

3. **Set up environment variables**

   Create a `.env` file based on `.env.example` and fill in the required values (e.g., JWT secret, database connection string).

4. **Run the application**
   ```bash
   npm start
   ```
   or
   ```bash
   yarn start
   ```

## Usage

- Register a new user via `/register`
- Log in via `/login` to receive a JWT
- Access protected routes by including the JWT in the Authorization header as a Bearer token

## Technologies

- Node.js
- Express.js
- JSON Web Token (JWT)
- bcrypt (for password hashing)
- [Add your database here, e.g., MongoDB, PostgreSQL, etc.]

## License

This project is licensed under the MIT License.
