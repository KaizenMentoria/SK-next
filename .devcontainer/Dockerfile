FROM mcr.microsoft.com/dotnet/sdk:8.0

RUN dotnet tool install --global dotnet-ef ; \
    dotnet tool install --global dotnet-aspnet-codegenerator ; \
    ln -s /root/.dotnet/tools/* /usr/local/bin/ ; \
    DEBIAN_FRONTEND=noninteractive apt update && apt upgrade -y && apt install -y openssh-client gnupg2;
