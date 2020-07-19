# Geektrust In Traffic Problem

## Problem Aprroach

Since C# is an object oriented language and the problem statement inspired me to create the following structured approach.

## Classes:

```	
Class Orbit
		<string> name
		<double> distance
		<double> no.of_craters
		<double> max_speed_allowed
```	
```	
Class Weather
		<string> weather_type
		<double> %_change_in_crater /*(increase: value>0, decrease: value<0, no change: value=0)*/`
```	
```	
Class Vehicle
		<string> vehicle_type
		<double> vehicle_speed
		<double> time_taken_to_cross_a_crater
		<Weather[]> supported_weathers
```

## Algorithm:

```
1. Initialized all the classes with required objects as per the problem statement
2. Read Input file
3. Call Process() with arguments: WEATHER ORBIT_1_TRAFFIC_SPEED ORBIT_2_TRAFFIC_SPEED
4. Initialize a variable with value -1 for holding intermediate mimimal time taken : MINIMUM_TIME_TAKEN
5. Save all vehicles which support the input weather in a list : ALL_VEHICLES
6. If no such vehicles found return empty string as output.
7. Else follow steps:
8. Save the weather object for the input weather in a var: WEATHER
9. Foreach Orbit (Step 10 - 13):
	10. Save actual no. of craters for an orbit for the input weather in CRATERS
		(No. of craters in the orbit)+(Increase in the craters due to weather)

	11. Foreach vehicle inside ALL_VEHICLES (Step 12-13)
		12. Calculate time taken by the vehicle
			Time taken by the vehicle=(Usual time taken by the vehicle) + (time delay due to craters),
			where 	Usual time taken by the vehicle= Orbit distance/Vehicle speed
					time delay due to craters=(time taken to cross a crater) X (no. of actual craters due to weather)
		13. if Time taken by the vehicle < MINIMUM_TIME_TAKEN
				update MINIMUM_TIME_TAKEN
				save Output: VEHICLE_NAME ORBIT_NO
			else check the next vehicle
14. Print the Output
```
## Run
```
dotnet build -o geektrust
dotnet geektrust/geektrust.dll <absolute_path_to_input_file>
```