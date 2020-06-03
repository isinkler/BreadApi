FROM mcr.microsoft.com/dotnet/core/sdk:3.1

COPY . /app

WORKDIR /app

RUN dotnet tool install -g dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

RUN mkdir -p /media/uploads/images
RUN mkdir -p /media/uploads/images/restaurant
RUN mkdir -p /media/uploads/images/user

EXPOSE 5000/tcp

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh