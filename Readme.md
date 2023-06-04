# GIS Structures 

GIS Structures as defined in David Lewin's _Generalized Musical Intervals and Transformations_  are the backbone of the library as those allow us to switch between different ways of thinking through Congruence between interval systems. Congruence also means that we can do Calculations on an already implemented GIS and then map the result back.

# Exposed Features 

## Note System 

As in [tonal.js](https://github.com/tonaljs/tonal/tree/main/packages/note):

- name 
- pitch class 
- letter 
- accidentals
- alteration 
- octave

## Scale System : Exlusively Pitch Classes?  

- Scale Types: Defined as Intervals
- Scales: Instances of Scale Types.

- Extensible: User should be able to add new Scale Types to exhaust the current scale obsessions.
- Scale Detection

## Rhythm

# Extension Methods (maybe for the builders?)

## Midi 
    using Midi Specification as Congruence
    - Note <> Midi Note 
    - Duration <> Midi Duration

## Frequencies 
    using Tuning Systems as Congruence  (More like: Tuning System is a Congruence that shall explicitly be named as such)
    - Note <> Frequency 
