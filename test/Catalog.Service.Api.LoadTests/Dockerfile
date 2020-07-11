FROM maven:3.5.3-jdk-8-alpine AS build-env
WORKDIR /build
COPY pom.xml .
RUN mvn dependency:go-offline

COPY src/ /build/src/
RUN mvn package

FROM adoptopenjdk/openjdk8:alpine-slim
WORKDIR /opt/app
COPY --from=build-env /build/target .
ENTRYPOINT ["sh", "-c", "java -Dlogback.configurationFile=logback.xml -jar catalog-load-tests-1.0.jar -s ${LOAD_TESTS_SIMULATION_NAME}"]
