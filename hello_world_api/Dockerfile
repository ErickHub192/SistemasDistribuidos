
FROM golang:1.23 as build

WORKDIR /app

COPY go.mod ./

RUN go mod download

COPY . .

RUN CGO_ENABLED=0 GOOS=linux go build -o /api ./cmd/api/

EXPOSE 80

CMD ["/api"]