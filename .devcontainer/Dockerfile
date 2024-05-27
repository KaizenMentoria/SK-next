FROM mcr.microsoft.com/dotnet/sdk:8.0

RUN dotnet tool install --global dotnet-ef ; \
    dotnet tool install --global dotnet-aspnet-codegenerator ; \
    dotnet tool install --global csharprepl ; \
    dotnet tool install --global csharpier ; \
    ln -s /root/.dotnet/tools/* /usr/local/bin/ ; 
