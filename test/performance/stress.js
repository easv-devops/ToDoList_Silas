import http from 'k6/http';

export let options = {
    stages: [
        { duration: '1m', target: 200 },
        { duration: '5m', target: 200 },
        { duration: '1m', target: 600 },
        { duration: '5m', target: 600 },
        { duration: '1m', target: 800 },
        { duration: '5m', target: 800 },
        { duration: '1m', target: 1000 },
        { duration: '5m', target: 1000 },
        { duration: '5m', target: 0 },
    ]
};

export default function () {
    http.get("http://167.86.105.61:5002/Items");

    check(response, {
        'status is 200': (r) => r.status === 200
    });
}