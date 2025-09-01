from flask import Flask, render_template, request, redirect
import GuitarGodsNewGuitarist
import GuitarGodsNewSong
import GuitarGodsReadOneGuitarist
import GuitarGodsReadOneSong
import GuitarGodsReadAllGuitarists
import GuitarGodsReadAllSongs
import GuitarGodsUpdateGuitarist
import GuitarGodsUpdateSong
import GuitarGodsDeleteGuitarist
import GuitarGodsDeleteSong

app = Flask(__name__)

guitaristinfo = []
songinfo = []

@app.route("/")
def homePage():
    return render_template("index.html")


@app.route("/songs")
def songs():
    return render_template("songsuggest.html")


@app.route("/contact")
def contact():
    return render_template("contact.html")


@app.route("/admin")
def admin():
    return render_template("adminbase.html")


@app.route("/newguitarist", methods = ['POST', 'GET'])
def newGuitarist():
    if request.method == 'POST':
        name = request.form['name']
        if not name:
            errormsg = "Please enter a name!"
        else:
            errormsg = ""
            description = request.form['description']
            picture = request.form['picture']
            link = request.form['link']
            successCode = GuitarGodsNewGuitarist.insertGuitarist(name, description, picture, link)
            if successCode == 0:
                errormsg = "Guitarist has been added!"
                guitaristinfo.append(f'{name} | {description} | {picture} | {link}')
            else:
                errormsg = "Database ERROR -- Guitarist already exists"
        return render_template("newguitarist.html", guitaristinfo = guitaristinfo, errormsg = errormsg)
    else:
        return render_template("newguitarist.html")


@app.route("/newsong", methods = ['POST', 'GET'])
def newSong():
    if request.method == 'POST':
        songName = request.form['songName']
        if not songName:
            errormsg = "Please enter a song name!"
        else:
            errormsg = ""
            artistName = request.form['name']
            songLink = request.form['songLink']
            successCode = GuitarGodsNewSong.insertSong(artistName, songName, songLink)
            if successCode == 0:
                errormsg = "Song has been added!"
                songinfo.append(f'{artistName} | {songName} | {songLink}')
            else:
                errormsg = "Database ERROR -- Song already exists"
        return render_template("newsong.html", songinfo = songinfo, errormsg = errormsg)
    else:
        return render_template("newsong.html")


@app.route("/readallguitarists")
def readallGuitarists():
    guitaristinfo = ""
    guitaristinfo = GuitarGodsReadAllGuitarists.readAll()
    return render_template("readallguitarists.html", guitaristinfo = guitaristinfo)


@app.route("/readallsongs")
def readallSongs():
    songinfo = ""
    songinfo = GuitarGodsReadAllSongs.readAll()
    return render_template("readallsongs.html", songinfo = songinfo)


@app.route("/updateguitarist", methods = ['POST', 'GET'])
def updateGuitarist():
    if request.method == "POST":
        name = ""
        description = ""
        picture = ""
        link = ""
        if request.form['btnID'] == "Search":
            name = request.form['name']
            if not name:
                errormsg = "You have to enter a guitarist's name"
                return render_template('updateguitarist.html', errormsg = errormsg)
            else:
                errormsg = ""
                name, description, picture, link = GuitarGodsReadOneGuitarist.readGuitarist(name)
                if not name:
                    errormsg = "Database ERROR -- Guitarist not found"
                else:
                    errormsg = ""
            return render_template("updateguitarist.html", name = name, description = description, picture = picture, link = link)
        elif request.form['btnID'] == "Update":
            print('Processing Update...')
            name = request.form['guitarist']
            print(name)
            if not name:
                errormsg = "You have to search for a guitarist first before you are able to update!"
                return render_template('updateguitarist.html', errormsg = errormsg)
            else:
                description = request.form['description']
                print(description)
                picture = request.form['picture']
                print(picture)
                link = request.form['link']
                print(link)
                updated = GuitarGodsUpdateGuitarist.updateGuitarist(name, description, picture, link)
                if updated == 0:
                    errormsg = "Database ERROR"
                else:
                    errormsg = "Guitarist Updated!"
            return render_template("updateguitarist.html", name = name, description = description, picture = picture, link = link, errormsg = errormsg)
    else:
        return render_template("updateguitarist.html")


@app.route("/updatesong", methods = ['POST', 'GET'])
def updateSong():
    if request.method == "POST":
        artistName = ""
        songName = ""
        songLink = ""
        if request.form['btnID'] == "Search":
            songName = request.form['name']
            if not songName:
                errormsg = "You have to enter a song name"
                return render_template('updatesong.html', errormsg = errormsg)
            else:
                errormsg = ""
                artistName, songName, songLink = GuitarGodsReadOneSong.readSong(songName)
                if not songName:
                    errormsg = "Database ERROR -- Song not found"
                else:
                    errormsg = ""
            return render_template("updatesong.html", artistName = artistName, songName = songName, songLink = songLink)
        elif request.form['btnID'] == "Update":
            print('Processing Update...')
            songName = request.form['songName']
            print(songName)
            if not songName:
                errormsg = "You have to search for a song first before you are able to update!"
                return render_template('updatesong.html', errormsg = errormsg)
            else:
                artistName = request.form['artistName']
                print(artistName)
                songLink = request.form['songLink']
                print(songLink)
                updated = GuitarGodsUpdateSong.updateSong(artistName, songName, songLink)
                if updated == 0:
                    errormsg = "Database ERROR"
                else:
                    errormsg = "Song Updated!"
            return render_template("updatesong.html", artistName = artistName, songName = songName, songLink = songLink, errormsg = errormsg)
    else:
        return render_template("updatesong.html")

@app.route('/readDeleteGuitarist')
def readDeleteGuitarist():
    guitaristinfo = ""
    guitaristinfo = GuitarGodsReadAllGuitarists.readAll()
    return render_template("deleteguitarist.html", guitaristinfo = guitaristinfo)

@app.route("/deleteguitarist/<string:name>", methods = ['POST', 'GET'])
def deleteGuitarist(name):
    GuitarGodsDeleteGuitarist.deleteGuitarist(name)
    return redirect('/readDeleteGuitarist')

@app.route('/readDeleteSong')
def readDeleteSong():
    songinfo = ""
    songinfo = GuitarGodsReadAllSongs.readAll()
    return render_template("deletesong.html", songinfo = songinfo)

@app.route("/deletesong/<string:songName>", methods = ['POST', 'GET'])
def deleteSong(songName):
    GuitarGodsDeleteSong.deleteSong(songName)
    return redirect('/readDeleteSong')