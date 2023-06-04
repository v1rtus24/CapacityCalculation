SELECT MainCabSpec.ip,MainCabSpec.mission,MainCabSpec.size,MainCabSpec.placing, PLC.brand,PLC.model 
FROM MainCabSpec  
JOIN PLC ON PLC.Id = MainCabSpec.PLC_id
WHERE MainCabSpec.Id = 8