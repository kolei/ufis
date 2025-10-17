from http.server import BaseHTTPRequestHandler
from http.server import HTTPServer
import random

class HttpGetHandler(BaseHTTPRequestHandler):
    """Обработчик с реализованным методом do_GET."""

    def do_GET(self):
        self.send_response(200)
        self.send_header('Content-Type', 'application/json')
        self.end_headers()
        bad_symbol = "" if random.randint(0, 1) == 0 else "!@^$*#"[random.randint(0,5)]
        last_name = ['Иванов','Петров','Сидоров'][random.randint(0,2)]
        first_name = ['Иван','Пётр','Сидор'][random.randint(0,2)]
        middle_name = ['Иванович','Петрович','Сидорович'][random.randint(0,2)]
        self.wfile.write(f'{{"value":"{last_name}{bad_symbol} {first_name} {middle_name}"}}'.encode(encoding='utf_8'))


def run():
  server_address = ('', 4444)
  httpd = HTTPServer(server_address, HttpGetHandler)
  try:
      httpd.serve_forever()
  except KeyboardInterrupt:
      httpd.server_close()

if __name__ == "__main__":
    run()