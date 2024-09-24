import { sleep, check } from 'k6';
import { Options } from 'k6/options';
import http from 'k6/http';
import { Trend } from 'k6/metrics';

const waitingSnapshot = new Trend('waiting_time_snapshot', true);
const waitingMonitor = new Trend('waiting_time_monitor', true);

export let options: Options = {
  scenarios: {
    main: {
      executor: 'ramping-vus',
      startVUs: 100,
      stages: [
        {duration: '10s', target: 10},
        {duration: '30s', target: 100},
        {duration: '10s', target: 300},
      ]
    }
  },
  thresholds: {
    http_req_failed: [{threshold: 'rate<0.01', abortOnFail: true, delayAbortEval: "3s"}],
    'http_req_duration{request_type:index}': [{threshold: 'med < 100', abortOnFail: true, delayAbortEval: "3s"}],
    'http_req_duration{request_type:moreload}': [{threshold: 'med < 500', abortOnFail: true, delayAbortEval: "3s"}]
  },
};

export default () => {
  const resSnapshot = http.get('https://localhost:7149/snapshot/text');
  check(resSnapshot, {
    'Snapshot status is 200': () => resSnapshot.status === 200,
  });
  waitingSnapshot.add(resSnapshot.timings.waiting)

  const resMonitor = http.get('https://localhost:7149/snapshot/text');
  check(resMonitor, {
    'Monitor status is 200': () => resMonitor.status === 200,
  });
  waitingMonitor.add(resMonitor.timings.waiting)
  
  sleep(1);
};
