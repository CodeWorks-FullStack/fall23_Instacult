import { AppState } from "../AppState.js";
import { Cult } from "../models/Cult.js";
import {Cultist} from "../models/Cultist.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class CultsService {

async getCults() {
  const res = await api.get('api/cults')
  logger.log('[CULTS]', res.data)
  AppState.cults = res.data.map((cult) => new Cult(cult))
}

async getCultById(cultId) {
  AppState.activeCult = null
  const res = await api.get(`api/cults/${cultId}`)
  logger.log('[CULT]', res.data)
  AppState.activeCult = new Cult(res.data)
}

async getCultist(cultId) {
  logger.log('[CULT ID]', cultId)
  const res = await api.get(`api/cults/${cultId}/cultMembers`)
  logger.log('[CULTIST]', res.data)
  AppState.cultist = res.data.map((cultist) => new Cultist(cultist))
}

async joinCult(cultId) {
const cultData = {cultId: cultId}
logger.log('[CULT ID]', cultData)
const res = await api.post('api/cultMembers', cultData)
logger.log('[CULTIST]', res.data)
AppState.activeCult.memberCount++
AppState.cultist.push(new Cultist(res.data))
}

async createCult(cultData) {
  const res = await api.post('api/cults', cultData)
  logger.log('[CULT]', res.data)
  AppState.cults.push(new Cult(res.data))
}

async leaveCult(cultMemberId) {
  const res = await api.delete(`api/cultMembers/${cultMemberId}`)
  logger.log('[MESSAGE]', res.data)
  AppState.cultist = AppState.cultist.filter((cultist) => cultist.cultMemberId != cultMemberId)
}

}

export const cultsService = new CultsService();
