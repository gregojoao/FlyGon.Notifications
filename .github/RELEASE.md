# Como Publicar uma Nova Versão no NuGet

Este projeto usa GitHub Actions para automatizar a publicação de pacotes NuGet.

## Pré-requisitos

1. **NuGet API Key**: Você precisa ter uma chave de API do NuGet.org
   - Acesse: https://www.nuget.org/account/apikeys
   - Crie uma nova API Key com permissão de "Push"
   - Adicione como secret no GitHub: `Settings > Secrets and variables > Actions > New repository secret`
   - Nome do secret: `NUGET_API_KEY`

## Processo de Release

### 1. Atualizar a Versão

Edite o arquivo `src/FlyGon.Notifications/FlyGon.Notifications.csproj` e atualize:

```xml
<Version>2.0.0</Version>
<AssemblyVersion>2.0.0.0</AssemblyVersion>
<FileVersion>2.0.0.0</FileVersion>
<PackageReleaseNotes>Descrição das mudanças...</PackageReleaseNotes>
```

### 2. Commit e Push

```bash
git add src/FlyGon.Notifications/FlyGon.Notifications.csproj
git commit -m "Bump version to 2.0.0"
git push origin master
```

### 3. Criar uma Tag de Versão

```bash
# Criar tag localmente
git tag v2.0.0

# Enviar tag para o GitHub
git push origin v2.0.0
```

**Importante**: A tag deve seguir o formato `v*.*.*` (exemplo: v2.0.0, v2.1.0, v2.0.1)

### 4. Publicação Automática

Quando você faz push da tag, o GitHub Actions automaticamente:

1. ✅ Compila o projeto
2. ✅ Executa todos os testes
3. ✅ Cria o pacote NuGet
4. ✅ Publica no NuGet.org
5. ✅ Cria uma Release no GitHub com o pacote anexado

### 5. Verificar a Publicação

- **GitHub**: Vá em `Actions` para ver o progresso do workflow
- **NuGet.org**: Acesse https://www.nuget.org/packages/FlyGon.Notifications/
- **GitHub Releases**: Vá em `Releases` para ver a nova versão

## Versionamento Semântico

Siga o [Semantic Versioning](https://semver.org/):

- **MAJOR** (X.0.0): Mudanças incompatíveis na API
- **MINOR** (x.Y.0): Novas funcionalidades compatíveis
- **PATCH** (x.y.Z): Correções de bugs compatíveis

## Exemplo Completo

```bash
# 1. Atualizar versão no .csproj para 2.1.0
# 2. Commit
git add src/FlyGon.Notifications/FlyGon.Notifications.csproj
git commit -m "Bump version to 2.1.0 - Add new validation methods"
git push origin master

# 3. Criar e enviar tag
git tag v2.1.0
git push origin v2.1.0

# 4. Aguardar o GitHub Actions completar (3-5 minutos)
# 5. Verificar em https://www.nuget.org/packages/FlyGon.Notifications/
```

## Troubleshooting

### Erro: "Package already exists"
- Você não pode republicar a mesma versão
- Incremente a versão e crie uma nova tag

### Erro: "Invalid API Key"
- Verifique se o secret `NUGET_API_KEY` está configurado corretamente
- Verifique se a API Key não expirou

### Workflow não executou
- Verifique se a tag segue o formato `v*.*.*`
- Verifique em `Actions` se há erros no workflow

## Publicação Manual (Alternativa)

Se preferir publicar manualmente:

```bash
# Build
dotnet build --configuration Release

# Pack
dotnet pack src/FlyGon.Notifications/FlyGon.Notifications.csproj --configuration Release --output ./artifacts

# Publish
dotnet nuget push ./artifacts/FlyGon.Notifications.2.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```
