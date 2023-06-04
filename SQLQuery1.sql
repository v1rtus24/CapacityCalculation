
SELECT WellPad.WellPad_id,  COUNT(*) AS SignalCount 
FROM PhysChar 
 JOIN Well ON PhysChar.Well_id = Well.Well_id 
 JOIN  WellPad ON Well.WellPad_id = WellPad.WellPad_id
Where PhysChar.signal = 'AO' AND WellPad.WellPad_id = 27
GROUP BY  WellPad.WellPad_id