# Script para atualizar testes do NUnit 3.x para NUnit 4.x

$testFiles = Get-ChildItem -Path "tests\FlyGon.Notifications.Test" -Filter "*Tests.cs" -Recurse | Where-Object { $_.FullName -notlike "*\obj\*" }

foreach ($file in $testFiles) {
    $content = Get-Content $file.FullName -Raw
    
    # Substituir Assert.True por Assert.That com Is.True
    $content = $content -replace 'Assert\.True\(([^)]+)\)', 'Assert.That($1, Is.True)'
    
    # Substituir Assert.False por Assert.That com Is.False
    $content = $content -replace 'Assert\.False\(([^)]+)\)', 'Assert.That($1, Is.False)'
    
    # Substituir Assert.IsTrue por Assert.That com Is.True
    $content = $content -replace 'Assert\.IsTrue\(([^)]+)\)', 'Assert.That($1, Is.True)'
    
    # Substituir Assert.IsFalse por Assert.That com Is.False
    $content = $content -replace 'Assert\.IsFalse\(([^)]+)\)', 'Assert.That($1, Is.False)'
    
    # Substituir Assert.AreEqual por Assert.That com Is.EqualTo
    $content = $content -replace 'Assert\.AreEqual\(([^,]+),\s*([^)]+)\)', 'Assert.That($2, Is.EqualTo($1))'
    
    # Substituir Assert.AreNotEqual por Assert.That com Is.Not.EqualTo
    $content = $content -replace 'Assert\.AreNotEqual\(([^,]+),\s*([^)]+)\)', 'Assert.That($2, Is.Not.EqualTo($1))'
    
    Set-Content -Path $file.FullName -Value $content -NoNewline
    Write-Host "Atualizado: $($file.Name)"
}

Write-Host "Todos os testes foram atualizados!"
