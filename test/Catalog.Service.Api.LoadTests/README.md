https://github.com/staciewaleyko/gatling-jar-example

1. Build jar
```
docker run -ti --rm -v ${PWD}:/build --mount 'type=volume,src=maven_repo,dst=/root/.m2' -w /build maven:3.5.3-jdk-8-alpine mvn package
```

2. Run jar
TODO: Why `-Dlogback.configurationFile=logback.xml` doesn't work in this command?
```
docker run -it --rm -v ${PWD}/target:/opt/app -w /opt/app adoptopenjdk/openjdk8:alpine-slim java -jar rate-limiting-1.0.jar -s ratelimiting.items.BrowseItemsCatalogSimulation
```

Other [command line options](https://gatling.io/docs/current/general/configuration#command-line-options) to io.gatling.app.Gatling
