# Team2-diploming-work

Diploming work for ITStep School. This project is a copy of Netflix.

install video.js here:
https://videojs.org/docs/guides/installation/react?template=vite&media=hls

This is for custom shadcn buttons and other stuff:
Build your custom preset on https://ui.shadcn.com/create?command=init&base=base&template=vite
Then copy and run the command from ui.shadcn.com.

## Local development (database and cache)

Requirements:
- Docker Desktop (Windows/macOS) or Docker Engine with Compose v2 (Linux)

Start:
1. `cp .env.example .env`
2. Edit .env and set your own admin, password, db
3. `docker compose up -d`

Check:
- `docker compose ps`
Both services should show `(healthy)` in the STATUS column.

Backend connection string:
`Host=localhost;Port=5432;Database=<DB_NAME>;Username=<DB_ADMIN>;Password=<DB_PASSWORD>`