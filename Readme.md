## Windows run
script: dist/get-200-status-test.js
scenarios: (100.00%) 1 scenario, 300 max VUs, 1m20s max duration (incl. graceful stop):
* main: Up to 300 looping VUs for 50s over 3 stages (gracefulRampDown: 30s, gracefulStop: 30s)


     ✓ Snapshot status is 200
     ✓ Monitor status is 200

     checks.........................: 100.00% ✓ 8180       ✗ 0
     data_received..................: 2.7 MB  53 kB/s
     data_sent......................: 1.2 MB  24 kB/s
     http_req_blocked...............: avg=353.4µs  min=0s      med=0s      max=56.18ms  p(90)=0s       p(95)=0s
     http_req_connecting............: avg=20.07µs  min=0s      med=0s      max=5.29ms   p(90)=0s       p(95)=0s
     http_req_duration..............: avg=16.54ms  min=0s      med=28.28ms max=109.94ms p(90)=31.33ms  p(95)=31.68ms
       { expected_response:true }...: avg=16.54ms  min=0s      med=28.28ms max=109.94ms p(90)=31.33ms  p(95)=31.68ms
     ✓ { request_type:index }.......: avg=0s       min=0s      med=0s      max=0s       p(90)=0s       p(95)=0s
     ✓ { request_type:moreload }....: avg=0s       min=0s      med=0s      max=0s       p(90)=0s       p(95)=0s
    ✓ http_req_failed................: 0.00%   ✓ 0          ✗ 16360
    http_req_receiving.............: avg=47.11µs  min=0s      med=0s      max=3.12ms   p(90)=129.32µs p(95)=506.7µs
    http_req_sending...............: avg=33.71µs  min=0s      med=0s      max=1.51ms   p(90)=0s       p(95)=506µs
    http_req_tls_handshaking.......: avg=324.92µs min=0s      med=0s      max=53.67ms  p(90)=0s       p(95)=0s
    http_req_waiting...............: avg=16.46ms  min=0s      med=27.98ms max=109.84ms p(90)=31.19ms  p(95)=31.57ms
    http_reqs......................: 16360   320.211721/s
    iteration_duration.............: avg=1.07s    min=1.06s   med=1.07s   max=1.29s    p(90)=1.07s    p(95)=1.07s
    iterations.....................: 4090    80.05293/s
    vus............................: 29      min=12       max=299
    vus_max........................: 300     min=300      max=300
    waiting_time_monitor...........: avg=30.51ms  min=26.56ms med=30.42ms max=37.5ms   p(90)=31.21ms  p(95)=31.59ms
    waiting_time_snapshot..........: avg=32.14ms  min=25.52ms med=30.79ms max=100.25ms p(90)=31.65ms  p(95)=32.09ms


running (0m51.1s), 000/300 VUs, 4090 complete and 0 interrupted iterations                                                                                                          
main ✓ [======================================] 000/300 VUs  50s

## Linux on Docker
execution: local
script: dist/get-200-status-test.js
output: -

scenarios: (100.00%) 1 scenario, 300 max VUs, 1m20s max duration (incl. graceful stop):
* main: Up to 300 looping VUs for 50s over 3 stages (gracefulRampDown: 30s, gracefulStop: 30s)


     ✓ Snapshot status is 200
     ✓ Monitor status is 200

     checks.........................: 100.00% ✓ 8328       ✗ 0
     data_received..................: 1.7 MB  34 kB/s
     data_sent......................: 770 kB  15 kB/s
     http_req_blocked...............: avg=25.81µs min=0s      med=0s      max=7.02ms   p(90)=0s      p(95)=0s
     http_req_connecting............: avg=19.33µs min=0s      med=0s      max=4.97ms   p(90)=0s      p(95)=0s
     http_req_duration..............: avg=25.22ms min=10.77ms med=22.07ms max=312ms    p(90)=25.26ms p(95)=27.66ms
       { expected_response:true }...: avg=25.22ms min=10.77ms med=22.07ms max=312ms    p(90)=25.26ms p(95)=27.66ms
     ✓ { request_type:index }.......: avg=0s      min=0s      med=0s      max=0s       p(90)=0s      p(95)=0s
     ✓ { request_type:moreload }....: avg=0s      min=0s      med=0s      max=0s       p(90)=0s      p(95)=0s
    ✓ http_req_failed................: 0.00%   ✓ 0          ✗ 8328
    http_req_receiving.............: avg=17.02µs min=0s      med=0s      max=1.52ms   p(90)=0s      p(95)=0s
    http_req_sending...............: avg=12.4µs  min=0s      med=0s      max=5.98ms   p(90)=0s      p(95)=0s
    http_req_tls_handshaking.......: avg=0s      min=0s      med=0s      max=0s       p(90)=0s      p(95)=0s
    http_req_waiting...............: avg=25.19ms min=10.77ms med=22.05ms max=311.49ms p(90)=25.25ms p(95)=27.65ms
    http_reqs......................: 8328    163.135892/s
    iteration_duration.............: avg=1.05s   min=1.03s   med=1.04s   max=1.34s    p(90)=1.05s   p(95)=1.05s
    iterations.....................: 4164    81.567946/s
    vus............................: 24      min=12       max=299
    vus_max........................: 300     min=300      max=300
    waiting_time_monitor...........: avg=21.76ms min=10.77ms med=21.95ms max=34.65ms  p(90)=23.54ms p(95)=25.73ms
    waiting_time_snapshot..........: avg=28.63ms min=11.33ms med=22.21ms max=311.49ms p(90)=26.16ms p(95)=28.37ms


running (0m51.0s), 000/300 VUs, 4164 complete and 0 interrupted iterations                                                                                                          
main ✓ [======================================] 000/300 VUs  50s      