FROM maven:3.5.3-jdk-8-alpine AS build-env
WORKDIR /build
COPY pom.xml .
RUN mvn dependency:go-offline

COPY src/ /build/src/
RUN mvn package

FROM adoptopenjdk/openjdk8:alpine-slim
WORKDIR /opt/app
COPY docker-entrypoint.sh .
COPY --from=build-env /build/target .
ENTRYPOINT ["sh", "/opt/app/docker-entrypoint.sh"]
CMD ["loadtests.catalog.BrowseItemsCatalogSimulation"]