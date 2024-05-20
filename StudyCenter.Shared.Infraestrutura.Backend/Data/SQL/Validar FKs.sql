SELECT 
    fk.name AS ForeignKeyName,
    tp.name AS TableSchema,
    tb.name AS TableName,
    cp.name AS ColumnName,
    rtp.name AS ReferencedTableSchema,
    rtb.name AS ReferencedTableName,
    rcp.name AS ReferencedColumnName
FROM 
    sys.foreign_keys AS fk
    INNER JOIN sys.foreign_key_columns AS fkc 
        ON fk.object_id = fkc.constraint_object_id
    INNER JOIN sys.tables AS tb 
        ON fkc.parent_object_id = tb.object_id
    INNER JOIN sys.schemas AS tp 
        ON tb.schema_id = tp.schema_id
    INNER JOIN sys.columns AS cp 
        ON fkc.parent_object_id = cp.object_id AND fkc.parent_column_id = cp.column_id
    INNER JOIN sys.tables AS rtb 
        ON fkc.referenced_object_id = rtb.object_id
    INNER JOIN sys.schemas AS rtp 
        ON rtb.schema_id = rtp.schema_id
    INNER JOIN sys.columns AS rcp 
        ON fkc.referenced_object_id = rcp.object_id AND fkc.referenced_column_id = rcp.column_id
ORDER BY 
    tp.name, tb.name, fk.name;
