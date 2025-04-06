# Dockerfile
FROM node:14

WORKDIR /app

# Copy package.json and install dependencies
COPY package*.json ./
RUN npm install

# Copy all files
COPY . .

# Build the application
RUN npm run build

# Serve the application
CMD ["npm", "start"]