import sqlite3


def getEntry():
    song = input("Enter Song Name: ")
    artistName, songName, songLink = readSong(song)
    if songName == "":
        songName = "ERROR"
    else:
        print(
            f'Artist Name: {artistName:<20} Song Name: {songName:<40} Song Link: {songLink:<40}')
    return artistName, songName, songLink


def readSong(song):
    artistName = ""
    songName = ""
    songLink = ""
    conn = None
    results = []
    try:
        conn = sqlite3.connect('guitargods.db')
        cur = conn.cursor()
        cur.execute(
            '''SELECT * FROM songs WHERE lower(songName) == ?''', (song.lower(),))
        results = cur.fetchall()
        for row in results:
            artistName = row[0]
            songName = row[1]
            songLink = row[2]
    except sqlite3.Error as err:
        print('Database ERROR', err)
    finally:
        if conn != None:
            conn.close()
    return artistName, songName, songLink


if __name__ == "__main__":
    getEntry()
