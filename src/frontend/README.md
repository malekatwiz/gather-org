# GatherOrg Frontend

This guide will help you set up and run the frontend part of the GatherOrg project.

## Prerequisites

Make sure you have the following installed on your local machine:
- [Node.js](https://nodejs.org/) (v14 or later)
- [npm](https://www.npmjs.com/) (v6 or later) or [yarn](https://yarnpkg.com/)

## Installation

1. **Clone the repository**

   ```sh
   git clone https://github.com/malekatwiz/gather-org.git
   cd gather-org/src/Frontend
   ```

2. **Install dependencies**

   ```sh
   npm install
   ```

   or if you prefer yarn:

   ```sh
   yarn install
   ```

## Running the Project

3. **Start the development server**

   ```sh
   npm start
   ```

   or if you prefer yarn:

   ```sh
   yarn start
   ```

4. **Open your browser**

   The application should be running at [http://localhost:3000](http://localhost:3000).

## Building the Project

To create a production build, run:

```sh
npm run build
```

or if you prefer yarn:

```sh
yarn build
```

The build artifacts will be stored in the `build/` directory.

## Additional Information

- **Linting**: To run the linter, use `npm run lint` or `yarn lint`.
- **Testing**: To run tests, use `npm test` or `yarn test`.

For more detailed information, refer to the [official React documentation](https://reactjs.org/docs/getting-started.html).