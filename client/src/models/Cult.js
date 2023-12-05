import { Profile } from "./Profile.js"

export class Cult {
  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt).toLocaleDateString()
    this.updatedAt = new Date(data.updatedAt).toLocaleDateString()
    this.name = data.name
    this.description = data.description
    this.coverImg = data.coverImg
    this.fee = data.fee
    this.invitationRequired = data.invitationRequired
    this.memberCount = data.memberCount
    this.leaderId = data.leaderId
    this.leader = new Profile(data.leader)
  }
}

const cult = {
    "name": "Arby's Lovers",
    "description": "In Verdant Grove, the 'Arby's Lovers' cult, led by the charismatic Cyrus Munchmore, worships the now-defunct fast-food giant. Clad in burgundy and beige robes adorned with roast beef motifs, members gather secretly for rituals chanting Arby's slogans and meditating on the spiritual power of curly fries. The belief centers on consuming Arby's offerings to attain a higher plane, connecting with a divine roast beef energy. Despite skepticism from the community about mind-altering condiments, the cult's online presence grows, attracting curious souls to their unconventional practices. The town remains divided, unsure if the Arby's Lovers are a harmless subculture or harbor a darker agenda.",
    "coverImg": "https://nmgprod.s3.amazonaws.com/media/files/1d/51/1d51b65adc598f30106c528add436e36/cover_image_1674480489.jpg.760x400_q85_crop_upscale.jpg",
    "fee": 7.99,
    "invitationRequired": false,
    "memberCount": 0,
    "leaderId": "656e029147ce3892a40d678b",
    "leader": {
        "name": "blake@hotmail.com",
        "picture": "https://s.gravatar.com/avatar/93fef580ef7c78f383dbe6f94332fb58?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fbl.png",
        "id": "656e029147ce3892a40d678b",
        "createdAt": "2023-12-04T16:47:19",
        "updatedAt": "2023-12-04T16:47:19"
    },
    "id": 1,
    "createdAt": "2023-12-04T16:49:29",
    "updatedAt": "2023-12-04T16:49:29"
}
