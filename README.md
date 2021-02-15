# Cache

A firearms record with description and origin.

Based on the [Personal Firearms Record](https://www.atf.gov/firearms/docs/guide/personal-firearms-record-atf-p-33128/download) provided by the ATF.

# Docker

## Build

```
$ docker build -t cache .
```

## Run

```
$ docker run -d -p 8080:80 -t cache
```

# Disclaimer

This project is not intended for production use. It was created as a means to learn Razor Pages with ASP.NET Core.