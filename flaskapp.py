from flask import Flask
app = Flask(__name__)

@app.route('/')
def hello_world():
  return """<html>
            <body>
            <form action='/' method='get' autocomplete='off'> 
            <input type='text' name='randNum' id='box' readonly><br/>
            <button onclick="genBtn(); return false;">Generate</button>
            </form>
            <script type="text/javascript">
            var unique = [];
            var dupe = [];
            var total = [];
            var k = 0;
            
            while(dupe.length < 250) {
                num = Math.floor((Math.random() * 1000000) + 1);
                if(unique.includes(num)) {
                    dupe.push(num);
                }
                else {
                    if(unique.length < 750) {
                        unique.push(num);
                    }
                }
            }
            var dupeCount = 0;
            var uniqueCount = 0;
            var i;
            for(i = 0; i < 1000; i++) {
                var num = Math.floor((Math.random() * 100) + 1);
                if(num < 75) {
                    if(uniqueCount < 750) {
                        total.push(unique[uniqueCount]);
                        uniqueCount += 1;
                    }
                    else {
                        if(dupeCount < 250) {
                            total.push(dupe[dupeCount]);
                            dupeCount += 1;
                        }
                    }
                }
                else {
                    if(dupeCount < 250) {
                        total.push(dupe[dupeCount]);
                        dupeCount += 1;
                    }
                    else {
                        if(uniqueCount < 750) {
                            total.push(uniqueCount[uniqueCount]);
                            uniqueCount +=1;
                        }
                    }
                }
            }
            function genBtn() {
                document.getElementById('box').value = total[k];
                k += 1;
                return false;
            }
            </script>
            </body>
            </html>"""

if __name__ == '__main__':
  app.run()