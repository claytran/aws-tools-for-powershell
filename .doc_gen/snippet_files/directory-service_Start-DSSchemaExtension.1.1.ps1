$ldif = Get-Content D:\Users\Username\Downloads\ExtendedSchema.ldf -Raw
Start-DSSchemaExtension -DirectoryId d-123456ijkl -CreateSnapshotBeforeSchemaExtension $true -Description ManagedADSchemaExtension -LdifContent $ldif