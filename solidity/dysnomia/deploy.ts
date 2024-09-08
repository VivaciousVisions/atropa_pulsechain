const fs = require('fs')
import { ethers } from 'ethers'

// execute remix.exeCurrent() from the > command prompt at the bottom of the remixz

const getContract = async (contractName: string, contractAddress, accountIndex?: number): Promise<ethers.Contract> => {
  if(accountIndex == undefined) accountIndex = 0;
  console.log(`getting contract ${contractName} as account ${accountIndex}`)
  const delegationsArtifactsPath = `browser/solidity/dysnomia/domain/delegations/artifacts/${contractName}.json`
  const libartifactsPath = `browser/solidity/dysnomia/lib/artifacts/${contractName}.json`
  const artifactsPath = `browser/solidity/dysnomia/artifacts/${contractName}.json`
  let metadata
  try { metadata = JSON.parse(await remix.call('fileManager', 'getFile', artifactsPath)) } catch {
    try { metadata = JSON.parse(await remix.call('fileManager', 'getFile', libartifactsPath)) } catch {
      metadata = JSON.parse(await remix.call('fileManager', 'getFile', delegationsArtifactsPath)) }
  }
  const signer = (new ethers.providers.Web3Provider(web3Provider)).getSigner(accountIndex)
  const factory = new ethers.ContractFactory(metadata.abi, metadata.data.bytecode.object, signer)
  const contract = new ethers.Contract(contractAddress, factory.interface, signer);
  return contract
}

const deploy = async (contractName: string, args: Array<any>, accountIndex?: number): Promise<ethers.Contract> => {
  if(accountIndex == undefined) accountIndex = 0;
  console.log(`deploying ${contractName} from account ${accountIndex}`)
  const delegationsArtifactsPath = `browser/solidity/dysnomia/domain/delegations/artifacts/${contractName}.json`
  const libartifactsPath = `browser/solidity/dysnomia/lib/artifacts/${contractName}.json`
  const artifactsPath = `browser/solidity/dysnomia/artifacts/${contractName}.json`
  let metadata
  try { metadata = JSON.parse(await remix.call('fileManager', 'getFile', artifactsPath)) } catch {
    try { metadata = JSON.parse(await remix.call('fileManager', 'getFile', libartifactsPath)) } catch {
      metadata = JSON.parse(await remix.call('fileManager', 'getFile', delegationsArtifactsPath)) }
  }
  const signer = (new ethers.providers.Web3Provider(web3Provider)).getSigner(accountIndex)
  const factory = new ethers.ContractFactory(metadata.abi, metadata.data.bytecode.object, signer)
  const contract = await factory.deploy(...args)
  await contract.deployed()
  return contract
}

let result
let r2wtf
let vmreqaddress
let shafactoryaddress
let shiofactoryaddress
let yiaddress
let zhengaddress
let zhouaddress
let yauaddress
let yangaddress
let siuaddress //= ethers.utils.getAddress("0x3be998c75ae8CD79E808B0038DAFF593D60DC4f4")
let voidaddress = ethers.utils.getAddress("0xadB32aAbfF725AD7CE891dA81681070E6b8d64a0")
let libattributeaddress //= ethers.utils.getAddress("0x53D09dc8896bf463A7561199da0d56a5Ca25223b")
let laufactoryaddress //= ethers.utils.getAddress("0x492043DbfaAA1AC15E1566750ab7EDb63F05C85C")
let lauaddress
let libstringsaddress
let nymaddress
let libyaiaddress = ethers.utils.getAddress("0x021Fb1C5D7E94885f443F5E8b774c4f097cF4816")
let qingfactoryaddress = ethers.utils.getAddress("0x49A7e4307482f48B0980a412CEda05039a6DE077")
let qingaddress
let START = 0;
// set pre-requisite address to deploy only subset

(async () => {
  try {
    switch (START) {
      case 0:
        result = await deploy('VMREQ', [])
        console.log(`VMREQ address: ${result.address}`)
        vmreqaddress = result.address

      case 1:
        result = await deploy('SHAFactory', [])
        console.log(`SHAFactory address: ${result.address}`)
        shafactoryaddress = result.address

      case 2:
        result = await deploy('SHIOFactory', [])
        console.log(`SHIOFactory address: ${result.address}`)
        shiofactoryaddress = result.address

      case 3:
        result = await deploy('YI', [shafactoryaddress, shiofactoryaddress, vmreqaddress])
        console.log(`YI address: ${result.address}`)
        yiaddress = result.address

      case 4:
        result = await deploy('ZHENG', [yiaddress])
        console.log(`ZHENG address: ${result.address}`)
        zhengaddress = result.address

      case 5:
        result = await deploy('ZHOU', [zhengaddress])
        console.log(`ZHOU address: ${result.address}`)
        zhouaddress = result.address

      case 6:
        result = await deploy('YAU', [zhouaddress])
        console.log(`YAU address: ${result.address}`)
        yauaddress = result.address

      case 7:
        result = await deploy('YANG', [yauaddress])
        console.log(`YANG address: ${result.address}`)
        yangaddress = result.address

      case 8:
        result = await deploy('SIU', [yangaddress])
        console.log(`SIU address: ${result.address}`)
        siuaddress = result.address

      case 9:
        result = await deploy('VOID', [siuaddress])
        console.log(`VOID address: ${result.address}`)
        voidaddress = result.address

      case 10:
        result = await deploy('ATTRIBUTE', [voidaddress]) 
        console.log(`ATTRIBUTE address: ${result.address}`)
        libattributeaddress = result.address

      case 11:
        result = await deploy('LAUFactory', [voidaddress]) 
        console.log(`LAUFactory address: ${result.address}`)
        laufactoryaddress = result.address

      case 12:
        result = await deploy('STRINGLIB', [voidaddress]) 
        console.log(`STRINGLIB address: ${result.address}`)
        libstringsaddress = result.address

      case 13:
        result = await deploy('Nym', [voidaddress]) 
        console.log(`Nym address: ${result.address}`)
        nymaddress = result.address

      case 14:
        result = await deploy('YAI', [voidaddress]) 
        console.log(`YAI address: ${result.address}`)
        libyaiaddress = result.address

      case 15:
        result = await deploy('QINGFactory', [libyaiaddress]) 
        console.log(`QINGFactory address: ${result.address}`)
        qingfactoryaddress = result.address

      case 16:
        let qingfactorycontract = await getContract('QINGFactory', qingfactoryaddress)
        result = await qingfactorycontract["New(address)"](voidaddress)
        console.log(`QINGFactory Contract retrieved: ${qingfactoryaddress}`)
        r2wtf = await result.wait()
        qingaddress = r2wtf.events[0].address
        console.log(`QING Deployed: ${qingaddress} from origin`)

        qingfactorycontract = await getContract('QINGFactory', qingfactoryaddress, 2)
        result = await qingfactorycontract["New(address)"](libyaiaddress)
        r2wtf = await result.wait()
        qingaddress = r2wtf.events[0].address
        console.log(`QING Deployed: ${qingaddress} from non-origin`)

      case 99:
        let laufactorycontract = await getContract('LAUFactory', laufactoryaddress)
        result = await laufactorycontract["New(string,string)"]("User Test", "USERTOKEN")
        r2wtf = await result.wait()
        lauaddress = r2wtf.events[0].address
        console.log(`LAU Deployed: ${lauaddress} from origin`)
        let laucontract = await getContract('LAU', lauaddress)
        result = await laucontract["Username(string)"]("mariarahel")
        console.log("successful Set Username from origin")
        result = await laucontract["Chat(string)"]("Chat Test")
        console.log("successful Chat from origin")

        laufactorycontract = await getContract('LAUFactory', laufactoryaddress, 2)
        result = await laufactorycontract["New(string,string)"]("User Test 2", "USERTOKEN2")
        r2wtf = await result.wait()
        lauaddress = r2wtf.events[0].address
        console.log(`LAU Deployed: ${lauaddress} from non-origin`)
        laucontract = await getContract('LAU', lauaddress, 2)
        result = await laucontract["Username(string)"]("TestUser")
        console.log("successful Set Username from non-origin")
        result = await laucontract["Chat(string)"]("Chat Test 2")
        console.log("successful Chat from non-origin")
    }
  } catch (e) {
    console.log(e.message)
  }
})()
