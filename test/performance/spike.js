import http from 'k6/http';

export let options = {
    stages: [

    ],
    thresholds: {
        http_req_duration: ['p(95)<500']
    },
};

export default function () {
    http.get("http://167.86.105.61:5002/todolist");
}