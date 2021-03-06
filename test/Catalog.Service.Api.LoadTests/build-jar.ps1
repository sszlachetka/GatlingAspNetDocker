docker run `
    -ti `
    --rm `
    -v ${PWD}:/build `
    --mount 'type=volume,src=maven_repo,dst=/root/.m2' `
    -w /build `
    maven:3.5.3-jdk-8-alpine mvn package