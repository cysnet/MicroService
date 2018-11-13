FROM microsoft/dotnet:2.1-aspnetcore-runtime
MAINTAINER yishi.chen

LABEL description="this is a test docker2 project"
LABEL version="1.0"

ENV ASPNETCORE_ENVIRONMENT="Development"


WORKDIR /app
COPY . .
EXPOSE 1000
ENTRYPOINT ["dotnet","DockerTest2.dll","--port","1000"]
RUN echo "image done"

CMD echo "done"