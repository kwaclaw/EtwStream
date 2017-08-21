For /R %%G IN (upload\*.nupkg) do (
    ..\.nuget\nuget.exe push "%%G" -Source "http://40.123.48.16/MyFeed/api/v2/package" -ApiKey "DB420C35-E51D-4B1C-A5F5-FF73732683B9"
)

pause