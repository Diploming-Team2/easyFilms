# ---- Stage 1: Build ----
# Node.js LTS on Alpine (pinned version for reproducible builds)
FROM node:26.13.1-alpine AS build

# Working directory inside the container
WORKDIR /app

# Copy dependency manifests first to leverage Docker layer caching
COPY frontend/package.json frontend/package-lock.json /app/

# Install exact dependency versions from package-lock.json
RUN npm ci

# Copy the rest of the source code
COPY /frontend/ .

# Build the production bundle (TypeScript check + Vite build)
RUN npm run build

# ---- Stage 2: Serve ----
# Nginx stable on Alpine to serve static files
FROM nginx:1.30.7-alpine

# Copy only the built files from the build stage
COPY --from=build /app/dist /usr/share/nginx/html