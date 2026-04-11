import random
import time
from datetime import datetime, timezone

import requests

API_URL = "http://localhost:5182/api/sensors" 

MACHINE_IDS = ["M1", "M2", "M3"]


def generate_payload():
    machine_id = random.choice(MACHINE_IDS)

    temperature = round(random.uniform(60, 90), 2)
    pressure = round(random.uniform(100, 160), 2)

    return {
        "machineId": machine_id,
        "temperature": temperature,
        "pressure": pressure,
        "timestamp": datetime.now(timezone.utc).isoformat()
    }


def main():
    while True:
        payload = generate_payload()

        try:
            response = requests.post(API_URL, json=payload, timeout=5)
            print(f"Sent: {payload} | Status: {response.status_code} | Response: {response.text}")
        except requests.RequestException as exc:
            print(f"Error while sending data: {exc}")

        time.sleep(2)


if __name__ == "__main__":
    main()